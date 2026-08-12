using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSHandleRefObject : IBSHandleRefObject
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x10)]
        public struct Internal
        {
            internal enum Unknown
            {
                kRefCountMask = 0x3FF,
                kHandelValid = 1 << 10
            }

            internal NiRefObject.Internal Base;
        }
    }

    public interface IBSHandleRefObject : INiRefObject;
}
