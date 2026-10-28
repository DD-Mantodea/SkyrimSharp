namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct BSTSmallArrayHeapAllocator
    {
        public struct Internal
        {
            internal uint Capacity;

            internal uint Local;

            internal void* Data;
        }
    }
}
