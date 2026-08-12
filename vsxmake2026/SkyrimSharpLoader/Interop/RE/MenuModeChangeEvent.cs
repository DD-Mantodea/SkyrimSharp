namespace SkyrimSharpLoader.Interop.RE
{
    public struct MenuModeChangeEvent
    {
        [Flags]
        public enum MenuMode
        {
            kNone = -1,
            kHidden = 0,
            kDisplayed = 1
        }

        public BSFixedString Menu;

        public MenuMode Mode;
    }
}
