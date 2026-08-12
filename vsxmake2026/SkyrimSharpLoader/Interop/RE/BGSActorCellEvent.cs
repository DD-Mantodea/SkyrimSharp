namespace SkyrimSharpLoader.Interop.RE
{
    public struct BGSActorCellEvent
    {
        [Flags]
        public enum CellFlag
        {
            kEnter = 0,
            kLeave = 1
        }

        internal BGSActorEvent Base;

        internal uint CellID;

        internal CellFlag Flags;
    }
}
