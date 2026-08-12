namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSTArray<T> : IBSTArray where T : unmanaged
    {
        public struct Internal
        {
            internal BSTArrayHeapAllocator.Internal Base_0;

            internal BSTArrayBase.Internal Base_1;
        }
    }

    public interface IBSTArray : IBSTArrayHeapAllocator, IBSTArrayBase;
}
