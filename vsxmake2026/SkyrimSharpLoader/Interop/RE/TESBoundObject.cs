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

        static TESBoundObject()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_TESBoundObject", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_TESBoundObject", 0));
            _vtables.Add("TESObject", VTABLES.Get("VTABLE_TESBoundObject", 0));
            _vtables.Add("TESBoundObject", VTABLES.Get("VTABLE_TESBoundObject", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

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
