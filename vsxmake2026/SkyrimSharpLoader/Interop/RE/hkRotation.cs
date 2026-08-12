using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 16, Size = 0x30)]
    public struct hkRotation
    {
        internal hkMatrix3 Base;
    }
}
