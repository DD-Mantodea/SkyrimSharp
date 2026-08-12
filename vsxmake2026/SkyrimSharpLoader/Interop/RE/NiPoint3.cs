using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0xC)]
    public struct NiPoint3
    {
        internal float X;

        internal float Y;

        internal float Z;
    }
}
