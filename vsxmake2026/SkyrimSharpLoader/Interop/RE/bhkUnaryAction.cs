namespace SkyrimSharpLoader.Interop.RE
{
    public class bhkUnaryAction : IbhkUnaryAction
    {
        public struct Internal
        {
            internal bhkAction.Internal Base;
        }
    }

    public interface IbhkUnaryAction : IbhkAction;
}
