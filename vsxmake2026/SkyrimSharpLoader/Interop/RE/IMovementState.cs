namespace SkyrimSharpLoader.Interop.RE
{
    public struct IMovementState : IIMovementState
    {
        internal IMovementInterface Base;
    }

    public interface IIMovementState : IIMovementInterface;
}
