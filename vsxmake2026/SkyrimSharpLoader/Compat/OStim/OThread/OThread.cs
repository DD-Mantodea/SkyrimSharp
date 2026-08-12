using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;

namespace SkyrimSharpLoader.Compat.OStim.OThread
{
    public unsafe class OThread(OThread.Internal* ptr) : IFromNative<OThread, OThread.Internal>
    {
        public struct Internal
        {
            internal void** Vtable;

            internal void* threadInterface;

            internal SharpThreadEventListener* CreateListener(nint @delegate) =>
                this.CallVirt<Internal, nint, Ptr<SharpThreadEventListener>>(@delegate, 0x0);

            internal void RegisterThreadStartListener(nint eventListener) =>
                this.CallVoidVirt<Internal, nint>(eventListener, 0x1);

            internal void RegisterNodeChangedListener(nint eventListener) =>
                this.CallVoidVirt<Internal, nint>(eventListener, 0x2);

            internal void RegisterThreadStopListener(nint eventListener) =>
                this.CallVoidVirt<Internal, nint>(eventListener, 0x3);

            internal bool IsThreadValid(uint threadID) =>
                this.CallVirt<Internal, uint, bool>(threadID, 0x4);

            internal uint GetActorPosition(uint threadID, uint formID) =>
                this.CallVirt<Internal, uint, uint, uint>(threadID, formID, 0x5);

            internal uint GetActorPosition(nint thread, uint formID) =>
                this.CallVirt<Internal, nint, uint, uint>(thread, formID, 0x6);
        }

        public nint Native { get; } = new(ptr);

        public static implicit operator OThread(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(OThread instance) => (Internal*)instance.Native;

        public static OThread FromNative(nint ptr) => new((Internal*)ptr);
    }

    public unsafe delegate void ThreadDelegate(Thread* thread);
}
