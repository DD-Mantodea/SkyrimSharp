using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSLoadFormBuffer : IBGSLoadFormBuffer
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x50)]
        public struct Internal
        {
            internal BGSLoadGameBuffer.Internal Base_0;

            internal BGSLoadFormData.Internal Base_1;

            internal byte GetVersion() => Base_0.GetVersion();

            internal void LoadDataEndian() => Base_0.LoadDataEndian();
        }
    }

    public interface IBGSLoadFormBuffer : IBGSLoadGameBuffer, IBGSLoadFormData;
}
