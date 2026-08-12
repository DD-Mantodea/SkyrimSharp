using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x24)]
    public unsafe struct NiMatrix3
    {
        public float M11; public float M12; public float M13;

        public float M21; public float M22; public float M23;

        public float M31; public float M32; public float M33;

        public float this[int row, int col]
        {
            get
            {
                if (row < 0 || row > 2 || col < 0 || col > 2)
                    throw new IndexOutOfRangeException();

                fixed (float* p = &M11)
                    return p[row * 3 + col];
            }
            set
            {
                if (row < 0 || row > 2 || col < 0 || col > 2)
                    throw new IndexOutOfRangeException();

                fixed (float* p = &M11)
                    p[row * 3 + col] = value;
            }
        }
    }
}
