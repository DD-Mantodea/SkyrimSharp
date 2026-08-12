using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkReferencedObject : IhkReferencedObject
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x10)]
        public struct Internal
        {
            public enum LockMode
            {
                kNone = 0,
                kAuto,
                kManual
            }

            public enum Unknown
            {
                kMemSize = 0x7FFF
            }

            internal hkBaseObject.Internal Base;

            internal ushort MemSizeAndFlags;

            internal volatile short ReferenceCount;

            internal uint pad0C;
        }
    }

    public interface IhkReferencedObject : IhkBaseObject;
}
