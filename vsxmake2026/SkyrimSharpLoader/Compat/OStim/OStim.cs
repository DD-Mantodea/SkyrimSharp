using Newtonsoft.Json;
using SkyrimSharpLoader.Compat.OStim.OStimStructures;
using SkyrimSharpLoader.Internal;
using static System.Formats.Asn1.AsnWriter;

namespace SkyrimSharpLoader.Compat.OStim
{
    public unsafe static class OStim
    {
        public static List<OStimScene> Scenes = [];

        public static List<OStimAction> Actions = [];

        public static string OStimPath = Path.Combine(Environment.CurrentDirectory, "Data\\SKSE\\Plugins\\Ostim");

        public static void Initialize()
        {
            LoadScenes();

            LoadActions();
        }

        public static void LoadScenes()
        {
            var scenesPath = Path.Combine(OStimPath, "scenes");

            if (!Path.Exists(scenesPath))
                return;

            var scenes = Directory.GetFiles(scenesPath, "*.json", SearchOption.AllDirectories);

            foreach (var sceneFile in scenes)
            {
                var json = File.ReadAllText(sceneFile);

                OStimScene? scene = null;

                try
                {
                    scene = JsonConvert.DeserializeObject<OStimScene>(json);
                }
                catch
                {
                    Logger.Error($"Error when deserialize OStim scene {sceneFile}");

                    continue;
                }

                if (scene == null)
                    continue;

                scene.ID = Path.GetFileNameWithoutExtension(sceneFile);

                Scenes.Add(scene);
            }
        }

        public static void LoadActions()
        {
            var actionsPath = Path.Combine(OStimPath, "actions");

            if (!Path.Exists(actionsPath))
                return;

            var actions = Directory.GetFiles(actionsPath, "*.json", SearchOption.AllDirectories);

            foreach (var actionFile in actions)
            {
                var json = File.ReadAllText(actionFile);

                OStimAction? action = null;

                try
                {
                    action = JsonConvert.DeserializeObject<OStimAction>(json);
                }
                catch
                {
                    Logger.Error($"Error when deserialize OStim scene {actionFile}");

                    continue;
                }

                if (action == null)
                    continue;

                action.ID = Path.GetFileNameWithoutExtension(actionFile);

                Actions.Add(action);
            }
        }
    }
}
