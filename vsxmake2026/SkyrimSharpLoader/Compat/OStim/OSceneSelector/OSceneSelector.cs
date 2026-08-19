using Newtonsoft.Json;
using SkyrimSharpLoader.Compat.OStim.OStimStructures;
using SkyrimSharpLoader.Extensions;
using SkyrimSharpLoader.Internal;
using System.Runtime.CompilerServices;
using static System.Formats.Asn1.AsnWriter;

namespace SkyrimSharpLoader.Compat.OStim.OSceneSelector
{
    public class OSceneSelector
    {
        public static List<OSceneConfig> SceneConfigs = [];

        public static string ConfigsPath = Path.Combine(OStim.OStimPath, "SceneConfigs");

        public static void Initialize()
        {
            if (!Directory.Exists(ConfigsPath))
                Directory.CreateDirectory(ConfigsPath);

            LoadConfigs();
        }

        public static void LoadConfigs()
        {
            if (!Directory.Exists(ConfigsPath))
                return;

            var configs = Directory.GetFiles(ConfigsPath, "*.json", SearchOption.AllDirectories);

            foreach (var configFile in configs)
            {
                var json = File.ReadAllText(configFile);

                OSceneConfig? config = null;

                try
                {
                    config = JsonConvert.DeserializeObject<OSceneConfig>(json);
                }
                catch
                {
                    Logger.Error($"Error when deserialize OStim scene {configFile}");

                    continue;
                }

                if (config == null)
                    return;

                SceneConfigs.Add(config);
            }
        }

        public unsafe struct SelectArgs
        {
            public char* ID;

            public char* Result;
        }

        public unsafe static int SelectByConfigPapyrus(IntPtr args, int sizeBytes)
        {
            if (sizeBytes != sizeof(SelectArgs))
                return 1;

            ref var sArgs = ref Unsafe.AsRef<SelectArgs>((void*)args);

            if (sArgs.ID == null)
                return 1;

            var ID = new string(sArgs.ID);

            var scene = RandomSelectByConfig(ID ?? "");

            var res = new Span<char>(sArgs.Result, scene.Length + 1);

            scene.AsSpan().CopyTo(res);

            res[scene.Length] = '\0';

            return 0;
        }

        public static List<OStimScene> SelectByConfig(string ID)
        {
            var config = SceneConfigs.FirstOrDefault(s => s.ID == ID);

            if (config == null)
                return [];

            List<OStimScene> scenes = OStim.Scenes;

            scenes = config.ActorType switch
            {
                ActorType.M => scenes.M(),
                ActorType.F => scenes.F(),
                ActorType.MF => scenes.MF(),
                ActorType.MM => scenes.MM(),
                ActorType.FF => scenes.FF(),
                ActorType.MFF => scenes.MFF(),
                ActorType.MMF => scenes.MMF(),
                ActorType.MFFF => scenes.MFFF(),
                ActorType.MMMF => scenes.MMMF(),
                ActorType.MFFFF => scenes.MFFFF(),
                ActorType.MMMMF => scenes.MMMMF(),
                _ => scenes
            };

            if (config.NoFurniture)
                scenes = scenes.NoFurniture();

            scenes = [.. scenes.Where(s => config.BlacklistID.All(id => s.ID != id))];

            return scenes
                .FromModPack(config.FromModPack)
                .AnyFemaleHasAnyTags(config.AnyFemaleHasAnyTags)
                .AnyMaleHasAllTags(config.AnyMaleHasAllTags)
                .AnyFemaleHasAllTags(config.AnyFemaleHasAllTags)
                .AllMaleHasAnyTags(config.AllMaleHasAnyTags)
                .AllFemaleHasAnyTags(config.AllFemaleHasAnyTags)
                .AllMaleHasAllTags(config.AllMaleHasAllTags)
                .AllFemaleHasAllTags(config.AllFemaleHasAllTags)
                .NoMaleHasAnyTags(config.NoMaleHasAnyTags)
                .NoFemaleHasAnyTags(config.NoFemaleHasAnyTags)
                .AnyMSoloActions(config.AnyMSoloActions)
                .AllMSoloActions(config.AllMSoloActions)
                .NoMSoloActions(config.NoMSoloActions)
                .AnyFSoloActions(config.AnyFSoloActions)
                .AllFSoloActions(config.AllFSoloActions)
                .NoFSoloActions(config.NoFSoloActions)
                .AnyFMActions(config.AnyFMActions)
                .AllFMActions(config.AllFMActions)
                .NoFMActions(config.NoFMActions)
                .AnyMFActions(config.AnyMFActions)
                .AllMFActions(config.AllMFActions)
                .NoMFActions(config.NoMFActions)
                .OnlyActions(config.OnlyActions)
                .AllTags(config.AllTags);
        }

        public static string RandomSelectByConfig(string ID)
        {
            var res = SelectByConfig(ID).Random();

            Logger.Debug($"Select ID: {ID}, result: {res}");

            return res;
        }
    }
}
