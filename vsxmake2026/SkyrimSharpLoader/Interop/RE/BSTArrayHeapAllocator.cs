using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSTArrayHeapAllocator : IBSTArrayHeapAllocator
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x10)]
        public struct Internal
        {
            internal void* Data;

            internal uint Capacity;
        }
    }

    public interface IBSTArrayHeapAllocator;
}
