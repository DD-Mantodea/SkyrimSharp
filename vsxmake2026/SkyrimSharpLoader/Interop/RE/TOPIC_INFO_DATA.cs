using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TOPIC_INFO_DATA
    {
        public enum TOPIC_INFO_FLAGS : ushort
        {
            kNone = 0, kStartSceneOnEnd = 1 << 0, kRandom = 1 << 1, kSayOnce = 1 << 2,
            kRequiresPlayerActivation = 1 << 3, kInfoRefusal = 1 << 4, kRandomEnd = 1 << 5,
            kEndRunningScene = 1 << 6, kIsForceGreet = 1 << 7, kPlayerAddress = 1 << 8,
            kForceSubtitle = 1 << 9, kCanMoveWhileGreeting = 1 << 10, kNoLIPFile = 1 << 11,
            kPostProcess = 1 << 12, kCustomSoundOutput = 1 << 13, kSpendsFavorPoints = 1 << 14
        }

        internal ushort Flags;
        internal ushort TimeUntilReset;
    }
}
