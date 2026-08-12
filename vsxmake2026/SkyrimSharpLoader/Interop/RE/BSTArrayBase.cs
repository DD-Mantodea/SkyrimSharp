using SkyrimSharpLoader.Interop.Extensions;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSTArrayBase : IBSTArrayBase
    {
        [StructLayout(LayoutKind.Sequential, Size = 0x4)]
        public struct Internal
        {
            [StructLayout(LayoutKind.Sequential, Size = 0x8)]
            public struct IAllocatorFunctor
            {
                internal bool Allocate(uint a_num, uint a_elemSize) => this.CallVirt<IAllocatorFunctor, uint, uint, bool>(a_num, a_elemSize, 0);

                internal bool Reallocate(uint a_minNewSizeInItems, uint a_frontCopyCount, uint a_shiftCount, uint a_backCopyCount, uint a_elemSize)
                    => this.CallVirt<IAllocatorFunctor, uint, uint, uint, uint, uint, bool>(a_minNewSizeInItems, a_frontCopyCount, a_shiftCount, a_backCopyCount, a_elemSize, 1);

                internal void Deallocate() => this.CallVoidVirt(2);
            }

            internal void** Vtable;

            private uint Size;
        }
    }

    public interface IBSTArrayBase;
}
