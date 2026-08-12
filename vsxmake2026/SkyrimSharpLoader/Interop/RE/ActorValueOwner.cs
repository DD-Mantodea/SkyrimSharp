namespace SkyrimSharpLoader.Interop.RE
{
    //TODO
    public unsafe readonly struct ActorValueOwner : IActorValueOwner
    {
        public struct Internal
        {
            internal void** Vtable;
        }
    }

    public interface IActorValueOwner;
}
