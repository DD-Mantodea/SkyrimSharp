using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class hkpCdBody
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x20)]
        public struct Internal
        {
            internal hkpShape.Internal* Shape;

            internal uint ShapeKey;

            internal uint pad0C;

            internal void* motion;

            internal Internal* Parent;
        }
    }
}
