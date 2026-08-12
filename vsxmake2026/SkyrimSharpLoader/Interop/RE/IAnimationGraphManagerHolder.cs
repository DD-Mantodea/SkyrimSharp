using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.NativeStructures;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct IAnimationGraphManagerHolder : IIAnimationGraphManagerHolder
    {
        public struct Internal
        {
            internal void** Vtable;

            internal bool NotifyAnimationGraph(ref BSFixedString a_eventName)
            {
                fixed (BSFixedString* ptr = &a_eventName)
                    return this.CallVirt<Internal, Ptr<BSFixedString>, bool>(ptr, 1);
            }

            //internal bool GetAnimationGraphManagerImpl()
        }
    }

    public interface IIAnimationGraphManagerHolder;
}
