using SkyrimSharpLoader.Extensions;
using SkyrimSharpLoader.Runtime;

using unsafe LogFunc = delegate* unmanaged<nint, void>;

namespace SkyrimSharpLoader.Internal
{
    public unsafe class Logger
    {
        internal static LogFunc _info;

        public static void Info(string msg) => _info(Core.WStr(msg));

        public static void Info(object msg) => Info(msg.NonNullString());

        internal static LogFunc _error;

        public static void Error(string msg) => _error(Core.WStr(msg));

        public static void Error(object msg) => Error(msg.NonNullString());

        internal static LogFunc _debug;

        public static void Debug(string msg) => _debug(Core.WStr(msg));

        public static void Debug(object msg) => Debug(msg.NonNullString());
    }
}
