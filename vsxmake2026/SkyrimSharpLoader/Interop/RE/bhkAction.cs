namespace SkyrimSharpLoader.Interop.RE
{
    public class bhkAction : IbhkAction
    {
        public struct Internal
        {
            internal bhkSerializable.Internal Base;
        }
    }

    public interface IbhkAction : IbhkSerializable;
}
