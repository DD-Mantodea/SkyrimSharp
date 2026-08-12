using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Size = 0x8)]
    public unsafe struct hkRefVariant
    {
        internal hkRefPtr<hkReferencedObject.Internal> Base;
    }
}
