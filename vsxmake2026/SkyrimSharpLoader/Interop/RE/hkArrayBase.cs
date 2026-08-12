using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkArrayBase<T> : IhkArrayBase<T> where T : unmanaged
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x10)]
        public struct Internal
        {
            public T* Data;

            public int Size;

            public int CapacityAndFlags;
        }
    }

    public interface IhkArrayBase<T>;
}
