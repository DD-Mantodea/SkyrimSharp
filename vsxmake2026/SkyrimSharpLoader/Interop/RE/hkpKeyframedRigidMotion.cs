using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public class hkpKeyframedRigidMotion : IhkpKeyframeRigidMotion
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x140)]
        public struct Internal
        {
            internal hkpMotion.Internal Base;

            // TODO
        }
    }

    public interface IhkpKeyframeRigidMotion : IhkpMotion;
}
