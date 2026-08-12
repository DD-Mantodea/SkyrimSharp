using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Size = 0x8)]
    public unsafe struct hkRefPtr<T> where T : unmanaged
    {
        internal T* Ptr;
    }
}
