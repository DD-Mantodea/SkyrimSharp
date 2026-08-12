using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkbBindable : IhkbBindable
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x30)]
        public struct Internal
        {
            internal hkReferencedObject.Internal Base;

            internal void** Vtable;

            internal hkRefPtr<hkbVariableBindingSet> VariableBindingSet;

            internal hkArray<hkRefVariant> CachedBindables;

            internal bool AreBindablesCached;

            internal byte pad29;

            internal ushort pad2A;

            internal uint pad2C;
        }
    }

    public interface IhkbBindable : IhkReferencedObject;
}
