namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class NiTPointerMap<TKey, TValue>(NiTPointerMap<TKey, TValue>.Internal* ptr) :
        NiTMapBase<TKey, TValue>((NiTMapBase<TKey, TValue>.Internal*)ptr),
        INiTPointerMap where TKey : unmanaged where TValue : unmanaged
    {
        public new struct Internal
        {
            internal NiTMapBase<TKey, TValue>.Internal Base;
        }
    }

    public interface INiTPointerMap : INiTMapBase;
}
