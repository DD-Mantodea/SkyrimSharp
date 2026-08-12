using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSIntrusiveRefCounted : IBSIntrusiveRefCounted
    {
        [StructLayout(LayoutKind.Sequential, Size = 0x4)]
        public struct Internal
        {
            internal volatile uint RefCount;
        }
    }

    public interface IBSIntrusiveRefCounted;
}
