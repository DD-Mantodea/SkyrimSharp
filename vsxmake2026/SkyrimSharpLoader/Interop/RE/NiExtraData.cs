using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public struct NiExtraData
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x18)]
        public struct Internal
        {
            internal NiObject.Internal Base;

            internal BSFixedString Name;
        }
    }
}
