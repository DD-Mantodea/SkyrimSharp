using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct bhkSerializable : IbhkSerializable
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x20)]
        public struct Internal
        {
            internal bhkRefObject.Internal Base;

            internal Internal* Serializable;

            //TODO
        }
    }

    public interface IbhkSerializable : IbhkRefObject;
}
