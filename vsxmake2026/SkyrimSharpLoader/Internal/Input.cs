using System.Runtime.CompilerServices;

namespace SkyrimSharpLoader.Internal
{
    public unsafe class Input
    {
        public struct ButtonEventArgs
        {
            public DXScanCode Keycode;

            public float heldDuration;

            public bool IsPressed;

            public bool IsRepeating;

            public bool IsDown;

            public bool IsHeld;

            public bool IsUp;
        }

        public static Action<ButtonEventArgs> BtnEvent;

        public static int ButtonEvent(IntPtr args, int sizeBytes)
        {
            if (sizeBytes != sizeof(ButtonEventArgs))
                return 1;

            var beArgs = Unsafe.Read<ButtonEventArgs>((void*)args);

            BtnEvent?.Invoke(beArgs);

            return 0;
        }
    }
}
