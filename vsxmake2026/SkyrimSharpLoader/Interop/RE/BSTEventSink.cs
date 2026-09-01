using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.NativeStructures;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSTEventSink<T> : IBSTEventSink<T> where T : unmanaged
    {
        public struct Internal
        {
            internal void** Vtable;

            internal BSEventNotifyControl ProcessEvent(T* a_event, BSTEventSource<T>.Internal* a_eventSource)
                => this.CallVirt<Internal, Ptr<T>, Ptr<BSTEventSource<T>.Internal>, BSEventNotifyControl>(a_event, a_eventSource, 1, Vtable);
        }
    }

    public interface IBSTEventSink<T>;
}
