using System.Collections.Concurrent;
using System.Diagnostics;
using System.Dynamic;
using System.Numerics;
using System.Reflection;
using Newtonsoft.Json.Linq;
using SkyrimSharpLoader.Extensions;
using SkyrimSharpLoader.Internal.JsDetector.DetectorObjects;
using SkyrimSharpLoader.Runtime;
using SkyrimSharpLoader.Utils;

namespace SkyrimSharpLoader.Internal.JsDetector
{
    public class JsDetector
    {
        internal static ConcurrentDictionary<string, DetectorModule> Modules = [];

        internal static ConcurrentDictionary<Type, List<MethodInfo>> ExtensionMethods = [];

        public static void Detect()
        {
            List<Type> allTypes = [
                ..typeof(JsDetector).Assembly.GetTypes()
            ];

            BindingUtils.Values.ForEach(i =>
            {
                if (i.Item2 is Type type)
                    allTypes.TryAdd(type);
                else if (i.Item2 is not ExpandoObject)
                    allTypes.TryAdd(i.Item2.GetType());
            });

            allTypes = [..allTypes.Where(t => !t.IsIllegal())];

            var task = AsyncTypeCollector.CollectAllRelatedTypesAsync(allTypes);

            task.ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    var types = task.Result;

                    var packagePath = Path.Combine(Pathes.SkyrimSharpPath, "Packages");

                    if(Directory.Exists(packagePath))
                        Directory.Delete(packagePath, true);

                    Directory.CreateDirectory(packagePath);

                    var namespaceGroups = types
                        .Where(t => t.Name != "")
                        .GroupBy(t => t.Namespace ?? (t.IsGlobalNamespace() ? "GlobalNamespace" : string.Empty))
                        .Where(g => g.Key != string.Empty)
                        .OrderBy(g => g.Key)
                        .ToList();

                    Parallel.ForEach(namespaceGroups, new ParallelOptions {
                        MaxDegreeOfParallelism = Environment.ProcessorCount
                    }, 
                    group => {
                        var module = new DetectorModule(group.Key);

                        Modules.TryAdd(group.Key, module);

                        foreach (var type in group)
                            module.AddType(type);
                    });

                    Parallel.ForEach(Modules.ToArray(), new ParallelOptions {
                        MaxDegreeOfParallelism = Environment.ProcessorCount
                    },
                    pair => {
                        var filePath = Path.Combine(packagePath, $"{pair.Key}.d.ts");

                        pair.Value.AddExtensions();

                        File.WriteAllText(filePath, pair.Value.Serialize());
                    });

                    File.WriteAllText(Path.Combine(Pathes.SkyrimSharpPath, "Packages", "global.d.ts"), new DetectorGlobal().Serialize());

                    #region jsconfig
                    var config = new JObject
                    {
                        ["include"] = new JArray
                        {
                            "./**/*.ts",
                            "./**/*.js"
                        }
                    };

                    var options = new JObject
                    {
                        ["module"] = "commonjs",
                        ["moduleResolution"] = "classic",
                        ["isolatedModules"] = true,
                        ["composite"] = true,
                        ["incremental"] = true,
                        ["allowJs"] = true,
                        ["checkJs"] = false,
                        ["target"] = "ES2023",
                        ["rootDir"] = "./Scripts",
                        ["baseUrl"] = "./Packages",
                        ["skipLibCheck"] = true,
                        ["skipDefaultLibCheck"] = true,
                        ["lib"] = new JArray
                        {
                            "ES6",
                            "ES2023"
                        },
                        ["typeRoots"] = new JArray
                        {
                            "./Packages"
                        }
                    };

                    config["compilerOptions"] = options;

                    File.WriteAllText(Path.Combine(Pathes.SkyrimSharpPath, "jsconfig.json"), config.ToString());

                    #endregion

                    Modules = [];

                    ExtensionMethods = [];
                }
                else
                {
                    Logger.Error(task.Exception?.ToString() ?? "JsDetector: type collection did not complete successfully");
                }
            });
        }
    }
}
