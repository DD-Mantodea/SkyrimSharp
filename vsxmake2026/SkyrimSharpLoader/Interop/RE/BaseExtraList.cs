namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct BaseExtraList
    {
        public struct PresenceBitfield
        {
            internal fixed byte Bits[0x18];
        }

        internal BSExtraData* Data;

        internal PresenceBitfield* Presence;
    }
}
