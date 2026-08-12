namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct Character : ICharacter
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
    }

    public interface ICharacter : IActor;
}
