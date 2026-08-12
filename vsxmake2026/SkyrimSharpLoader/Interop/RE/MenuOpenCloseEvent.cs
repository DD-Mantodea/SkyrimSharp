namespace SkyrimSharpLoader.Interop.RE
{
    public struct MenuOpenCloseEvent
    {
        public BSFixedString MenuName;

        public bool Opening;

        public byte pad09;

        public ushort pad0A;

        public uint pad0C;
    }
}
