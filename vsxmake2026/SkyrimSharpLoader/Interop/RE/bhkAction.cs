namespace SkyrimSharpLoader.Interop.RE
{
    public struct bhkAction : IbhkAction
    {
        public struct Internal
        {
            internal bhkSerializable.Internal Base;
        }
    }

    public interface IbhkAction : IbhkSerializable;
}
