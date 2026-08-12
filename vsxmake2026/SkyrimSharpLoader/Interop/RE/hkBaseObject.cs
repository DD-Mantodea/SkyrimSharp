using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkBaseObject : IhkBaseObject
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x8)]
        public struct Internal
        {
            internal void** Vtable;
        }
    }

    public interface IhkBaseObject;
}
