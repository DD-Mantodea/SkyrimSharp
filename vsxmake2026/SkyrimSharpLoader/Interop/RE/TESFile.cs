using SkyrimSharpLoader.Interop.Interfaces;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class TESFile(TESFile.Internal* ptr) : IFromNative<TESFile, TESFile.Internal>
    {
        public struct Internal
        {

        }
     
        public nint Native { get; } = new(ptr);

        public static implicit operator TESFile(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESFile instance) => (Internal*)instance.Native.ToPointer();

        public static TESFile FromNative(nint ptr) => new((Internal*)ptr);
    }
}
