using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x10)]
    public struct hkVector4
    {
        internal Vector128<float> Quad;
    }
}
