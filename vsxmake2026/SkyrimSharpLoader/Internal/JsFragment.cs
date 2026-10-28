using Jint;
using Jint.Native;
using Jint.Runtime.Interop;
using SkyrimSharpLoader.Extensions;
using SkyrimSharpLoader.Interop.RE;
using SkyrimSharpLoader.Runtime;
using SkyrimSharpLoader.Runtime.ModLoader;
using SkyrimSharpLoader.Utils;
using System.Reflection;

namespace SkyrimSharpLoader.Internal
{
    public class JsFragment
    {
        public static TopicInfoEventChannel TopicInfoEventChannel = new();

        public static Engine Engine = new();

        public static Dictionary<(string, uint, FragmentType), JsValue> Fragments = [];

        public static void RegisterFor(string pluginName, uint formID, FragmentType type, JsValue value)
        {
            Fragments.Add((pluginName, formID, type), value);
        }

        public static void Initialize()
        {
            try
            {
                Assembly[] assemblies = [
                    typeof(JsFragment).Assembly,
                    ..ModLoader.Assemblies
                ];

                var exts = AssemblyUtils.GetExtensionTypes([.. assemblies.Distinct()]);

                Engine = new Engine(option => {
                    option.AllowClr(assemblies);
                    option.AddExtensionMethods([.. exts]);
                    option.Interop.AllowSystemReflection = true;
                    option.Interop.AllowGetType = true;
                    option.AllowOperatorOverloading();
                    option.CatchClrExceptions(exception =>
                    {
                        Console.WriteLine($"[Jint] CLR Exception: {exception.Message}");

                        return true;
                    });
                });

                BindInnerMethods();

                LoadScripts();

                TopicInfoEventChannel.Register(Begin);

                TopicInfoEventChannel.Register(End);
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        public static void BindInnerMethods()
        {
            Engine.SetValue("require", (string path) => Engine.Evaluate($"importNamespace(\"{path}\")"));

            BindingUtils.BindInnerMethod("nettypeof", (TypeReference t) => t.ReferenceType);
        }

        public static void LoadScripts()
        {
            if (!Directory.Exists(Pathes.ScriptsPath))
                Directory.CreateDirectory(Pathes.ScriptsPath);

            var files = Directory.GetFiles(Pathes.ScriptsPath, "*.js", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var script = File.ReadAllText(file);

                Engine.Execute(script, file);
            }
        }

        public unsafe static TopicInfoEventChannel.EventHandler Begin = (eventName, args) =>
        {
            try
            {
                if (args.Type != TESTopicInfoEvent.TopicInfoEventType.kTopicBegin)
                    return;

                var id = args.TopicInfoFormID;

                var file = TESFile.LookupPluginByID(id);

                if (Fragments.TryGetValue((file.Filename, id & 0xFFF, FragmentType.Begin), out var value))
                {
                    Engine.Invoke(value, args.GetInfo(), []);
                }

                Logger.Info($"{id:X} {file.Filename}");
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + e.StackTrace);
            }
        };

        public unsafe static TopicInfoEventChannel.EventHandler End = (eventName, args) =>
        {
            try
            {
                if (args.Type != TESTopicInfoEvent.TopicInfoEventType.kTopicEnd)
                    return;

                var id = args.TopicInfoFormID;

                var file = TESFile.LookupPluginByID(id);

                if (Fragments.TryGetValue((file.Filename, id & 0xFFF, FragmentType.End), out var value))
                {
                    Engine.Invoke(value, args.GetInfo(), [args.SpeakerRef]);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + e.StackTrace);
            }
        };
    }

    public enum FragmentType
    {
        Begin,
        End
    }

    public sealed class TopicInfoEventChannel : EventChannel<TESTopicInfoEvent, TESTopicInfoEvent>
    {
        public override string EventName => "TopicInfoEvent";
    }
}
