using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct Character(Character.Internal* ptr) : ICharacter, IFromNative<Character, Character.Internal>
    {
        public static FormType FormType => FormType.ActorCharacter;

        [Flags]
        public enum RecordFlags : uint
        {
            kDeleted = 1 << 5,
            kStartsDead = 1 << 9,
            kPersistent = 1 << 10,
            kInitiallyDisabled = 1 << 11,
            kIgnored = 1 << 12,
            kNoAIAcquire = 1 << 25,
            kDontHavokSettle = 1 << 29
        }

        public struct Internal
        {
            internal Actor.Internal Base;
        }

        static Character()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_Character", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_Character", 0));
            _vtables.Add("TESObjectREFR", VTABLES.Get("VTABLE_Character", 0));
            _vtables.Add("Actor", VTABLES.Get("VTABLE_Character", 0));
            _vtables.Add("Character", VTABLES.Get("VTABLE_Character", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator Character(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(Character instance) => (Internal*)instance.Native.ToPointer();

        public static implicit operator TESObjectREFR(Character instance) => TESObjectREFR.FromNative(instance.Native);

        public static Character FromNative(nint ptr) => new((Internal*)ptr);
    }

    public interface ICharacter : IActor;
}
