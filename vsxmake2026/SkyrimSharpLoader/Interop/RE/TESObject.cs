using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct TESObject(TESObject.Internal* ptr) : ITESObject, IFromNative<TESObject, TESObject.Internal>
    {
        [Flags]
        public enum ChangeFlags
        {
            kObjectValue = 1 << 1,
            kObjectFullName = 1 << 2
        }

        public struct Internal
        {
            internal TESForm.Internal Base;
        }

        static TESObject()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_TESObject", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_TESObject", 0));
            _vtables.Add("TESObject", VTABLES.Get("VTABLE_TESObject", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator TESObject(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESObject instance) => (Internal*)instance.Native.ToPointer();

        public static TESObject FromNative(nint ptr) => new((Internal*)ptr);
    }

    public interface ITESObject : ITESForm;
}
