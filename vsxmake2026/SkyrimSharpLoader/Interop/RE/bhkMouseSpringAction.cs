namespace SkyrimSharpLoader.Interop.RE
{
    public struct bhkMouseSpringAction : IbhkMouseSpringAction
    {
        public struct Internal
        {
            internal bhkUnaryAction.Internal Base;
        }
    }

    public interface IbhkMouseSpringAction : IbhkUnaryAction;
}
