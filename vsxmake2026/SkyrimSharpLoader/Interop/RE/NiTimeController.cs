using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct NiTimeController
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x48)]
        public struct Internal
        {
            public enum CycleType
            {
                kLoop,
                kReverse,
                kClamp,

                kTotal
            }

            [Flags]
            public enum Flag
            {
                kAnimType_AppTime = 0 << 0,
                kAnimType_AppInit = 1 << 0,
                kAnimType_Mask = 1,

                kCycleType_Loop = 0 << 1,
                kCycleType_Reverse = 1 << 1,
                kCycleType_Clamp = 2 << 1,
                kCycleType_Mask = 6,

                kActive = 1 << 3,
                kPlayBackwards = 1 << 4,
                kManagerControlled = 1 << 5,
                kComputeScaledTime = 1 << 6,
                kForceUpdate = 1 << 7
            }

            internal NiObject.Internal Base;

            internal Flag Flags;

            internal ushort pad12;

            internal float Frequency;

            internal float Phase;

            internal float LoKeyTime;

            internal float HiKeyTime;

            internal float StartTime;

            internal float LastTime;

            internal float WeightedLastTime;

            internal float ScaledTime;

            internal uint pad34;

            internal NiObjectNET.Internal* Target;

            internal NiPointer<Internal> Next;
        }
    }
}
