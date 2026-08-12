using System.Runtime.InteropServices;

using unsafe NativeHandler = delegate* unmanaged<string, void>;

namespace SkyrimSharpLoader.Compat.Prisma.Callbacks
{
    public unsafe class JSListenerCallback(JSListenerCallback.JSListenerHandler handler)
    {
        public delegate void JSListenerHandler(string argument);

        internal NativeHandler _handler = (NativeHandler)Marshal.GetFunctionPointerForDelegate(handler);

        public static implicit operator NativeHandler(JSListenerCallback callback) => callback._handler;

        public static implicit operator JSListenerCallback(Action<string> handler) => new((argument) => handler(argument));
    }
}
