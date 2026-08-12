using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSAnimationGraphEvent : IBSAnimationGraphEvent
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x18)]
        public struct Internal
        {
            internal BSFixedString Tag;

            internal TESObjectREFR.Internal* Holder;

            internal BSFixedString Payload;
        }
    }

    public interface IBSAnimationGraphEvent;
}
