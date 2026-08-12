namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct NiPointer<T> where T : unmanaged
    {
        internal readonly T* Ptr;

        public T* Get()
        {
            return Ptr;
        }
    }
}
