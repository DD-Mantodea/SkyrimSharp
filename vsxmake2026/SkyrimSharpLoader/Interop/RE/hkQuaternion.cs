using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{

    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x10)]
    public struct hkQuaternion
    {
        internal hkVector4 Vec;
    }
}
