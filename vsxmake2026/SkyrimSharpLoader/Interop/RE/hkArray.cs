using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x10)]
    public struct hkArray<T> : IhkArray<T> where T : unmanaged
    {
        internal hkArrayBase<T>.Internal Base;
    }

    public interface IhkArray<T> : IhkArrayBase<T>;
}
