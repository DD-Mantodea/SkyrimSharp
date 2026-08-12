using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct bhkRefObject : IbhkRefObject
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x18)]
        public struct Internal
        {
            internal NiObject.Internal Base;

            internal hkRefPtr<hkReferencedObject.Internal> ReferencedObject;
        }
    }

    public interface IbhkRefObject : INiObject;
}
