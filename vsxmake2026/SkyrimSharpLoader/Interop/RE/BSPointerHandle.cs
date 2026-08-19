global using ObjectRefHandle = SkyrimSharpLoader.Interop.RE.BSPointerHandle<SkyrimSharpLoader.Interop.RE.TESObjectREFR.Internal>;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct BSPointerHandle<T> where T : unmanaged
    {
        private BSUntypedPointerHandle _handle;
    }

    public unsafe struct BSUntypedPointerHandle
    {
        public enum Unknown : uint
        {
            kFreeListBits = 21,
            kAgeShift = 5
        }

        private uint _handle;
    }
}
