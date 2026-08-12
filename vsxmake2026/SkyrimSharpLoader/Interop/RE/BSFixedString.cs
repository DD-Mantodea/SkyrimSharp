global using BSFixedString = SkyrimSharpLoader.Interop.RE.BSFixedString<char>;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct BSFixedString<T>(T* data) : IBSFixedString<T> where T : unmanaged
    {
        public ref T this[uint index]
        {
            get
            {
                if (index >= Size)
                    throw new IndexOutOfRangeException();

                return ref _data[index];
            }
        }

        public readonly ref T Front => ref _data[0];

        public readonly ref T Back => ref _data[Size - 1];

        public readonly uint Size => GetProxy() == null ? 0 : GetProxy()->Size;

        private readonly T* _data = data;

        private readonly BSStringPool.Entry* GetProxy() => _data == null ? null : (BSStringPool.Entry*)_data - 1;
    }

    public interface IBSFixedString<T>;
}
