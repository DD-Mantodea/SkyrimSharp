using SkyrimSharpLoader.Interop.Extensions;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct NiRefObject : INiRefObject
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x10)]
        public struct Internal
        {
            internal void** Vtable;

            internal volatile uint RefCount;

            internal uint pad0C;

            internal void DeleteThis() => this.CallVoidVirt(1);
        }
    }

    public interface INiRefObject;
}
