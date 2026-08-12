using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSTSmartPointer<T> where T : unmanaged
    {
        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct Internal
        {
            internal T* Ptr;
        }
    }
}
