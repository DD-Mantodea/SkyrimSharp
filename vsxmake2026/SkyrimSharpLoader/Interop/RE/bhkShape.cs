using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class bhkShape
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x28)]
        public struct Internal
        {
            internal bhkSerializable.Internal Base;

            internal MATERIAL_ID MaterialID;

            internal uint FilterInfo;
        }
    }
}
