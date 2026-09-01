using SkyrimSharpLoader.Interop.RE;

namespace SkyrimSharpLoader.Internal
{
    public unsafe static class AddressLib
    {
        internal static delegate* unmanaged<ulong, ulong> _id2offset;

        public static ulong ID2Offset(ulong id) => _id2offset == null ? 0 : _id2offset(id);

        internal static delegate* unmanaged<ulong> _base;

        public static ulong Base() => _base == null ? 0 : _base();

        public static ulong GetAddr(ulong id)
        {
            var offset = ID2Offset(id);

            if (offset == 0)
                return 0;

            return Base() + offset;
        }
    }
}
