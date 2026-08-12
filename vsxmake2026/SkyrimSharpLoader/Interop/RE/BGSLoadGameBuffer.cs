using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSLoadGameBuffer : IBGSLoadGameBuffer
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x28)]
        public struct Internal
        {
            internal void** Vtable;

            internal void* Buffer;

            internal ulong unk10;

            internal uint unk18;

            internal uint unk1C;

            internal uint unk20;

            internal uint BufferPosition;

            internal byte GetVersion()
            {
                var func = (delegate* unmanaged<Internal*, byte>)Vtable[1];

                fixed (Internal* ptr = &this)
                    return func(ptr);
            }

            internal void LoadDataEndian()
            {

            }
        }
    }

    public interface IBGSLoadGameBuffer;
}
