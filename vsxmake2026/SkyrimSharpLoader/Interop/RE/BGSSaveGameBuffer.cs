using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class BGSSaveGameBuffer
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x18)]
        public struct Internal
        {
            internal void** Vtable;

            internal void* Buffer;

            internal uint Size;

            internal uint BufferPosition;

            internal TESForm.Internal* GetForm() => this.CallVirt<Internal, Ptr<TESForm.Internal>>(1);

            internal TESObjectREFR.Internal* GetReference() => this.CallVirt<Internal, Ptr<TESObjectREFR.Internal>>(2);
        }
    }
}
