using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class BSSpinLock
    {
        [StructLayout(LayoutKind.Sequential, Size = 0x8)]
        public struct Internal
        {
            public enum Unknown
            {
                kFastSpinThreshold = 10000
            }

            internal volatile uint OwningThread;

            internal volatile uint LockCount;
        }
    }
}
