using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0xB0)]
    public struct hkMotionState
    {
        internal hkTransform Transform;

        internal hkSweptTransform SweptTransform;

        internal hkVector4 DeltaAngle;

        internal float ObjectRadius;

        internal hkHalf LinearDamping;

        internal hkHalf AngularDamping;

        internal hkHalf TimeFactor;

        internal hkUFloat8 MaxLinearVelocity;

        internal hkUFloat8 MaxAngularVelocity;

        internal byte Deactivationstruct;

        internal byte padAD;

        internal ushort padAE;
    }
}
