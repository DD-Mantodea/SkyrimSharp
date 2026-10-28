namespace SkyrimSharpLoader.Interop.RE
{
    public struct BSTSmallArray<T> : IBSTSmallArray where T : unmanaged
    {
        public struct Internal
        {
            internal BSTSmallArrayHeapAllocator.Internal Base_0;

            internal BSTArrayBase.Internal Base_1;
        }
    }

    public interface IBSTSmallArray;
}
