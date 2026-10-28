using SkyrimSharpLoader.Compat.OStim;
using SkyrimSharpLoader.Compat.OStim.OSceneSelector;
using SkyrimSharpLoader.Internal;
using SkyrimSharpLoader.Internal.JsDetector;
using SkyrimSharpLoader.Runtime.ModLoader;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Runtime
{
    public unsafe class Core
    {
        public static SkyrimSharpEventHandler Test;

        public static int Initialize(IntPtr args, int sizeBytes)
        {
            try
            {
                Logger.Info("SkyrimSharpLoader initialized.");

                OStim.Initialize();

                Logger.Info("OStim compat initialized.");

                OSceneSelector.Initialize();

                Logger.Info("OSceneSelector compat initialized.");

                JsFragment.Initialize();

                Logger.Info("JsFragment initialized.");

                JsDetector.Detect();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + e.StackTrace);
            }

            return 0;
        }

        public static int LoadContents(IntPtr args, int sizeBytes)
        {
            ModLoader.ModLoader.LoadAssemblies();

            return 0;
        }

        public static nint WStr(string str) => Marshal.StringToHGlobalUni(str);

        [StructLayout(LayoutKind.Sequential)]
        public struct InternalCallArgs
        {
            public char* Type;

            public char* Name;

            public IntPtr Method;

            public bool NoPublic;
        }

        public static int SetInternalCall(IntPtr args, int sizeBytes)
        {
            if (sizeBytes != sizeof(InternalCallArgs))
                return 1;

            var icArgs = Unsafe.Read<InternalCallArgs>((void*)args);

            var typeName = new string(icArgs.Type);

            var fieldName = new string(icArgs.Name);

            if (typeName == null || fieldName == null)
                return 1;

            var field = Assembly.GetExecutingAssembly().GetType(typeName)?.GetField(fieldName, BindingFlags.Static | (icArgs.NoPublic ? BindingFlags.NonPublic : BindingFlags.Public));

            if (field == null)
                return 1;

            try
            {
                field.SetValue(null, icArgs.Method);
            }
            catch (Exception e)
            {
                Logger.Error($"{typeName} {fieldName} set value failed: {e.Message}");

                return 0;
            }

            Logger.Debug($"{typeName} {fieldName} set successfully");

            return 0;
        }
    }
}
