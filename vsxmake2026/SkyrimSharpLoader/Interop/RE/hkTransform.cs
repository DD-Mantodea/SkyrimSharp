using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x40)]
    public struct hkTransform
    {
        internal hkRotation Rotation;

        internal hkVector4 Translation;
    }
}
