using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct NiCollisionObject : INiCollisionObject
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x18)]
        public struct Internal
        {
            internal NiObject.Internal Base;

            internal NiAVObject.Internal* SceneObject;
        }
    }

    public interface INiCollisionObject : INiObject;
}
