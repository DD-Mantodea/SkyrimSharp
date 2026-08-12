using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class hkpShape
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x20)]
        public struct Internal
        {
            [StructLayout(LayoutKind.Sequential, Size = 0x3)]
            public struct CalcSizeForSpuInput
            {
                internal bool MidphaseAgent3Registered;

                internal bool IsFixedOrKeyFramed;

                internal bool HasDynamicMotionSaved;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x60)]
            public struct ShapeFuncs
            {
                // TODO
            }

            [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x80)]
            public struct ShapeFuncs2
            {
                // TODO
            }

            internal hkReferencedObject.Internal Base;

            internal bhkShape.Internal* UserData;

            internal hkpShapeType Type;

            internal uint pad1C;
        }
    }
}
