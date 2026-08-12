using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSAnimationGraphChannel : IBSAnimationGraphChannel
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x20)]
        public struct Internal
        {
            internal void** Vtable;

            internal BSIntrusiveRefCounted.Internal Base;

            internal uint pad0C;

            internal BSFixedString ChannelName;

            internal uint Value;

            internal uint pad1C;
        }
    }

    public interface IBSAnimationGraphChannel : IBSIntrusiveRefCounted;
}
