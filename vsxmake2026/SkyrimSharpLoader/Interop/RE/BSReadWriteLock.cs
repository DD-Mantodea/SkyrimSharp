using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x8)]
    public struct BSReadWriteLock
    {
        public enum Unknown : uint
        {
            kLockWrite = 0x80000000,
            kLockCountMask = 0xFFFFFFF
        }

        private volatile uint WriterThread;

        private volatile uint Lock;
    }
}
