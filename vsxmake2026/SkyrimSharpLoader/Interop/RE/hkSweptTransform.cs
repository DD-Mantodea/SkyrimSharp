using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x50)]
    public struct hkSweptTransform
    {
        internal hkVector4 CenterOfMass0;

        internal hkVector4 CenterOfMass1;

        internal hkQuaternion Rotation0;

        internal hkQuaternion Rotation1;

        internal hkVector4 CenterOfMassLocal;
    }
}
