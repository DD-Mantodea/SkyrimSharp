namespace SkyrimSharpLoader.Interop.RE
{
    public class BSTSmallArray<T> : IBSTSmallArray where T : unmanaged
    {
        public struct Internal
        {
            internal BSTSmallArrayHeapAllocator.Internal Base_0;

            internal BSTArrayBase.Internal Base_1;
        }
    }

    public interface IBSTSmallArray;
}
