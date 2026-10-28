namespace SkyrimSharpLoader.Interop.RE
{
    //TODO
    public unsafe struct hkpWorld
    {
        public struct Internal
        {
            public enum MultiThreadingChecks
            {
                kEnable,
                kIgnore
            }

            public enum BroadPhaseType
            {
                kInvalid,
                kEntity,
                kPhantom,
                kPhaseBorder,

                kTotal
            }
        }
    }
}
