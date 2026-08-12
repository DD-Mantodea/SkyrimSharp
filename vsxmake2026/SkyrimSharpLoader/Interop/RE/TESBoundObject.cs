using SkyrimSharpLoader.Interop.Interfaces;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct TESBoundObject(TESBoundObject.Internal* ptr) : ITESBoundObject, IFromNative<TESBoundObject, TESBoundObject.Internal>
    {
        public struct Internal
        {
            public struct BOUND_DATA
            {
                public NiNPShortPoint3 BoundMin;

                public NiNPShortPoint3 BoundMax;
            }

            internal TESObject.Internal Base;

            internal BOUND_DATA BoundData;

            internal uint pad2C;
        }

        public nint Native { get; } = new(ptr);

        public static implicit operator TESBoundObject(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESBoundObject instance) => (Internal*)instance.Native.ToPointer();

        public static TESBoundObject FromNative(nint ptr) => new((Internal*)ptr);
    }

    public interface ITESBoundObject : ITESObject;

    public struct NiNPShortPoint3
    {
        public short x;

        public short y;

        public short z;
    }
}
