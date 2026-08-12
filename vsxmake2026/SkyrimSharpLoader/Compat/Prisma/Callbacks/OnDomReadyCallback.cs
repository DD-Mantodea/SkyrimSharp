using System.Runtime.InteropServices;

using unsafe NativeHandler = delegate* unmanaged<ulong, void>;

namespace SkyrimSharpLoader.Compat.Prisma.Callbacks
{
    public unsafe class OnDomReadyCallback(OnDomReadyCallback.OnDomReadyHandler handler)
    {
        public delegate void OnDomReadyHandler(ulong view);

        internal NativeHandler _handler = (NativeHandler)Marshal.GetFunctionPointerForDelegate(handler);

        public static implicit operator NativeHandler(OnDomReadyCallback callback) => callback._handler;

        public static implicit operator OnDomReadyCallback(Action<ulong> handler) => new((view) => handler(view));
    }
}
