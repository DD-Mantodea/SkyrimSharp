using System.Runtime.InteropServices;

using unsafe NativeHandler = delegate* unmanaged<string, void>;

namespace SkyrimSharpLoader.Compat.Prisma.Callbacks
{
    public unsafe class JSCallback(JSCallback.JSHandler handler)
    {
        public delegate void JSHandler(IntPtr result);

        internal NativeHandler _handler = (NativeHandler)Marshal.GetFunctionPointerForDelegate(handler);

        public static implicit operator NativeHandler(JSCallback? callback) => callback == null ? null : callback._handler;

        public static implicit operator JSCallback(Action<IntPtr>? handler) => new((result) => handler?.Invoke(result));
    }
}
