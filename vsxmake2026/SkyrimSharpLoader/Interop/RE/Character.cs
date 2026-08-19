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

            internal bool Activate(TESObjectREFR.Internal* a_targetRef, TESObjectREFR.Internal* a_activatorRef, byte a_arg3, TESBoundObject.Internal* a_object, int a_targetCount)
                => Base.Activate(a_targetRef, a_activatorRef, a_arg3, a_object, a_targetCount);
        }

        public nint Native { get; } = new(ptr);

        public static implicit operator Character(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(Character instance) => (Internal*)instance.Native.ToPointer();

        public static implicit operator TESObjectREFR(Character instance) => TESObjectREFR.FromNative(instance.Native);

        public static Character FromNative(nint ptr) => new((Internal*)ptr);

        public bool Activate(TESObjectREFR targetRef, TESObjectREFR activatorRef, byte arg3, TESBoundObject obj, int targetCount)
            => ((Internal*)Native.ToPointer())->Activate(targetRef, activatorRef, arg3, obj, targetCount);
    }

    public interface ICharacter : IActor;
}
