namespace SkyrimSharpLoader.Compat.Prisma
{
    public class PrismaView(ulong instance)
    {
        private ulong _instance = instance;

        public void RegisterJSListener(string functionName, Action<string> callback) => Prisma.RegisterJSListener(_instance, functionName, callback);

        public void Invoke(string script, Action<IntPtr>? callback = null) => Prisma.Invoke(_instance, script, callback);

        public bool HasFocus() => Prisma.HasFocus(_instance);

        public bool Focus(bool pauseGame = false, bool disableFocusMenu = false) => Prisma.Focus(_instance, pauseGame, disableFocusMenu);

        public void Unfocus() => Prisma.Unfocus(_instance);

        public void Show() => Prisma.Show(_instance);

        public void Hide() => Prisma.Hide(_instance);

        public bool IsHidden() => Prisma.IsHidden(_instance);

        public int GetScrollingPixelSize() => Prisma.GetScrollingPixelSize(_instance);

        public void SetScrollingPixelSize(int pixelSize) => Prisma.SetScrollingPixelSize(_instance, pixelSize);

        public bool IsValid() => Prisma.IsValid(_instance);

        public void Destory() => Prisma.Destory(_instance);

        public int GetOrder() => Prisma.GetOrder(_instance);

        public void SetOrder(int order) => Prisma.SetOrder(_instance, order);

        public void CreateInspectorView() => Prisma.CreateInspectorView(_instance);

        public void SetInspectorVisibility(bool visable) => Prisma.SetInspectorVisibility(_instance, visable);

        public bool GetInspectorVisibility() => Prisma.GetInspectorVisibility(_instance);

        public void SetInspectorBounds(float topLeftX, float topLeftY, uint width, uint height) => Prisma.SetInspectorBounds(_instance, topLeftX, topLeftY, width, height);

        public void RegisterConsoleCallback(Action<ulong, ConsoleMessageLevel, IntPtr> callback) => Prisma.RegisterConsoleCallback(_instance, callback);

        public static implicit operator PrismaView(ulong instance) => new(instance);

        public static implicit operator ulong(PrismaView view) => view._instance;

        public override string ToString() => _instance.ToString();
    }
}
