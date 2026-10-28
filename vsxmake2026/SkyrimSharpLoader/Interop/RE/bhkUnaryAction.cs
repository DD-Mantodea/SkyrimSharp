namespace SkyrimSharpLoader.Interop.RE
{
    public struct bhkUnaryAction : IbhkUnaryAction
    {
        public struct Internal
        {
            internal bhkAction.Internal Base;
        }
    }

    public interface IbhkUnaryAction : IbhkAction;
}
