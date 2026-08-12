namespace SkyrimSharpLoader.Interop.RE
{
    public class bhkMouseSpringAction : IbhkMouseSpringAction
    {
        public struct Internal
        {
            internal bhkUnaryAction.Internal Base;
        }
    }

    public interface IbhkMouseSpringAction : IbhkUnaryAction;
}
