using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    //TODO
    public unsafe readonly struct MagicTarget : IMagicTarget
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x18)]
        public struct Internal
        {

        }
    }

    public interface IMagicTarget;
}
