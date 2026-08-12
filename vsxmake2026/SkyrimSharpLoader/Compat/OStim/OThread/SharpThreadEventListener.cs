namespace SkyrimSharpLoader.Compat.OStim.OThread
{
    public unsafe readonly struct SharpThreadEventListener
    {
        internal readonly void** Vtable;

        private readonly void* _delegate;
    }
}
