namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct BSStringPool
    {
        public struct Entry
        {
            public enum Unknown
            {
                kWide = 1 << 15,
                kRefCountMask = 0x7FFF,
                kLengthMask = 0xFFFFFF
            }

            internal Entry* _left;

            internal ushort _flags;

            internal volatile ushort _crc;

            internal uint _length; // union Entry* _right

            public readonly uint Length => _length & (int)Unknown.kLengthMask;

            public readonly uint Size => Length;
        }
    }
}
