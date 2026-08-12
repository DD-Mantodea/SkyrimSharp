using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkpMotion : IhkpMotion
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x140)]
        public struct Internal
        {
            public enum Unknown
            {
                kNumInactiveFramesToDeactivate = 5
            }

            [Flags]
            public enum MotionType
            {
                kInvalid,
                kDynamic,
                kSphereInertia,
                kBoxInertia,
                kKeyframed,
                kFixed,
                kThinBoxInertia,
                kCharacter,

                kTotal
            }

            internal hkReferencedObject.Internal Base;

            internal MotionType Type;

            internal byte DeactivationIntegrateCounter;

            internal ushort DeactivationNumInactiveFrames;

            internal ushort pad016;

            internal ulong pad018;

            internal hkMotionState MotionState;

            internal hkVector4 InertiaAndMassInv;

            internal hkVector4 LinearVelocity;

            internal hkVector4 AngularVelocity;

            internal hkVector4* DeactivationRefPosition; // 2

            internal uint* DeactivationRefOrientation; // 2

            internal hkpMaxSizeMotion.Internal* SavedMotion;

            internal ushort SavedQualityTypeIndex;

            internal ushort pad132;

            internal hkHalf GravityFactor;

            internal ulong pad138;
        }
    }

    public interface IhkpMotion : IhkReferencedObject;
}
