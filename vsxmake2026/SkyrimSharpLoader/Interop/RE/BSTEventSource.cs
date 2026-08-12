using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSTEventSource<T> : IBSTEventSource<T> where T : unmanaged
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x58)]
        public struct Internal
        {
            internal BSTArray<Ptr<BSTEventSink<T>.Internal>>.Internal Sinks;

            internal BSTArray<Ptr<BSTEventSink<T>.Internal>>.Internal PendingRegisters;

            internal BSTArray<Ptr<BSTEventSink<T>.Internal>>.Internal PendingUnregisters;

            internal BSSpinLock.Internal Lock;

            internal bool Notifying;

            internal byte pad51;

            internal ushort pad52;

            internal uint pad54;
        }
    }

    public interface IBSTEventSource<T>;

    public enum BSEventNotifyControl
    {
        kContinue = 0,
        kStop = 1
    }
}
