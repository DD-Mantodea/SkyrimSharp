using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x30)]
    public struct hkMatrix3
    {
        internal hkVector4 col0;

        internal hkVector4 col1;

        internal hkVector4 col2;
    }
}
