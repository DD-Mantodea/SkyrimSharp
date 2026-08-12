using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct ActorState : IActorState
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x10)]
        public struct Internal
        {

        }
    }

    public interface IActorState : IIMovementState;
}
