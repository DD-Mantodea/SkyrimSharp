namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct TESObject : ITESObject
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
    }

    public interface ITESObject : ITESForm;
}
