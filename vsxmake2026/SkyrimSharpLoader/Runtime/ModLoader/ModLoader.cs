using Newtonsoft.Json;
using SkyrimSharpLoader.Internal;
using SkyrimSharpLoader.Runtime.ModLoader;
using System.Reflection;
using System.Runtime.Loader;

namespace SkyrimSharpLoader.Runtime.ModLoader
{
    public static class ModLoader
    {
        public static void LoadAssemblies()
        {
            foreach (var info in Directory.GetFiles(Pathes.ModPath, "*.smod"))
            {
                var json = File.ReadAllText(info);

                var modInfo = JsonConvert.DeserializeObject<ModInfo>(json);

                if (modInfo == null)
                    continue;

                var modPath = Path.GetFullPath(Path.Combine(Pathes.ModPath, modInfo.Assembly));

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

                File.WriteAllText(Path.Combine(Pathes.ModPath, "log.txt"), e.Message + e.StackTrace);
            }
        }
    }
}
