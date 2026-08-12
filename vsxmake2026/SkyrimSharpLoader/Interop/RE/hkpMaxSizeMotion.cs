using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public class hkpMaxSizeMotion
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x140)]
        public struct Internal
        {
            internal hkpKeyframedRigidMotion.Internal Base;
        }
    }
}
