using System.Runtime.InteropServices;

using unsafe NativeHandler = delegate* unmanaged<SkyrimSharpLoader.Compat.Prisma.ConsoleMessageLevel, nint, void>;

namespace SkyrimSharpLoader.Compat.Prisma.Callbacks
{
    public unsafe class ConsoleMessageCallback(ConsoleMessageCallback.ConsoleMessageHandler handler)
    {
        public delegate void ConsoleMessageHandler(ulong view, ConsoleMessageLevel level, IntPtr ptr);

        internal NativeHandler _handler = (NativeHandler)Marshal.GetFunctionPointerForDelegate(handler);

        public static implicit operator NativeHandler(ConsoleMessageCallback callback) => callback._handler;

        public static implicit operator ConsoleMessageCallback(Action<ulong, ConsoleMessageLevel, IntPtr> handler) => new((view, level, ptr) => handler(view, level, ptr));
    }
}
