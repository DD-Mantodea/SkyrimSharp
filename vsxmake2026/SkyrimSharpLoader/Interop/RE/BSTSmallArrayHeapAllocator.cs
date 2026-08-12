namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class BSTSmallArrayHeapAllocator
    {
        public struct Internal
        {
            internal uint Capacity;

            internal uint Local;

            internal void* Data;
        }
    }
}
