using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.NativeStructures;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class TESFullName(TESFullName.Internal* ptr) : ITESFullName
    {
        public struct Internal
        {
            internal BaseFormComponent.Internal Base;

            internal BSFixedString FullName;
        }

        static TESFullName()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_TESObject", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_TESObject", 0));
            _vtables.Add("TESObject", VTABLES.Get("VTABLE_TESObject", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator TESFullName(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESFullName instance) => (Internal*)instance.Native.ToPointer();

        public static TESFullName FromNative(nint ptr) => new((Internal*)ptr);
    }

    public interface ITESFullName : IBaseFormComponent;
}
