namespace SkyrimSharpLoader.Interop.Standard
{
    public unsafe struct String
    {
        private fixed char _buf[16];

        private ulong _size;

        private ulong _res;
    }
}
