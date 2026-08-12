namespace SkyrimSharpLoader.Interop.RE
{
    public struct PositionPlayerEvent
    {
        [Flags]
        public enum EVENT_TYPE
        {
            kPre = 0,
            kPreUpdatePackages = 1,
            kPostUpdatePackages = 2,
            kPost = 3,
            kFinish = 4
        }

        public EVENT_TYPE Type;
    }
}
