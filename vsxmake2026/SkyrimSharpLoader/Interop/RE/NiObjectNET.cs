using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct NiObjectNET : INiObjectNET
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x30)]
        public struct Internal
        {
            internal NiObject.Internal Base;

            internal BSFixedString Name;

            internal NiPointer<NiTimeController.Internal> Controllers;

            internal NiExtraData.Internal** Extra;

            internal ushort ExtraDataSize;

            internal ushort MaxSize;

            internal uint pad2C;
        }
    }

    public interface INiObjectNET : INiObject;
}
