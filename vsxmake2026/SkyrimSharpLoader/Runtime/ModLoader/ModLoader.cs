using Newtonsoft.Json;
using SkyrimSharpLoader.Internal;
using SkyrimSharpLoader.Runtime.ModLoader;
using System.Reflection;
using System.Runtime.Loader;

namespace SkyrimSharpLoader.Runtime.ModLoader
{
    public static class ModLoader
    {
        public static List<Assembly> Assemblies = [];

        public static void LoadAssemblies()
        {
            if (!Directory.Exists(Pathes.ModsPath))
                Directory.CreateDirectory(Pathes.ModsPath);

            foreach (var infoFile in Directory.GetFiles(Pathes.ModsPath, "*.smod"))
            {
                var json = File.ReadAllText(infoFile);

                ModInfo? modInfo = null;

                try
                {
                    modInfo = JsonConvert.DeserializeObject<ModInfo>(json);
                }
                catch
                {
                    Logger.Error($"Error when deserialize smod {infoFile}");

                    continue;
                }

                if (modInfo == null)
                    continue;

                var modPath = Path.GetFullPath(Path.Combine(Pathes.ModsPath, modInfo.Assembly));

                LoadAssembly(modPath);
            }
        }

        public static void LoadAssembly(string path)
        {
            try
            {
                var asm = AssemblyLoadContext.GetLoadContext(Assembly.GetExecutingAssembly())?.LoadFromAssemblyPath(path);

                if (asm == null)
                    return;

                Assemblies.Add(asm);

                var types = asm.GetTypes();

                var modTypes = types.Where(t => t.IsSubclassOf(typeof(Mod))).ToList();

                if (modTypes.Count != 1)
                    return;

                var modType = modTypes[0];

                var modInstance = Activator.CreateInstance(modType) as Mod;

                modInstance?.Load();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + e.StackTrace);

                File.WriteAllText(Path.Combine(Pathes.ModsPath, "log.txt"), e.Message + e.StackTrace);
            }
        }
    }
}
