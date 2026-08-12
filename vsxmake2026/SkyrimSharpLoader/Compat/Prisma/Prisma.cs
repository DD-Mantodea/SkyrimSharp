using SkyrimSharpLoader.Compat.Prisma.Abstracts;
using SkyrimSharpLoader.Compat.Prisma.Callbacks;
using SkyrimSharpLoader.Internal;
using System.Runtime.InteropServices;
using unsafe GetBool = delegate* unmanaged<ulong, bool>;
using unsafe GetInt = delegate* unmanaged<ulong, int>;
using unsafe SetBool = delegate* unmanaged<ulong, bool, void>;
using unsafe SetInt = delegate* unmanaged<ulong, int, void>;
using unsafe VoidInteraction = delegate* unmanaged<ulong, void>;

namespace SkyrimSharpLoader.Compat.Prisma
{
    public unsafe class Prisma
    {
        public static Action OnInitializeUI;

        public static CreateViewChannel CreateViewChannel = new();

        public static int InitializeUI(IntPtr args, int sizeBytes)
        {
            try
            {
                foreach (var type in typeof(Prisma).Assembly.GetTypes())
                {
                    if (type.IsSubclassOf(typeof(RegisterView)))
                    {
                        var obj = Activator.CreateInstance(type);

                        if (obj is not RegisterView rw)
                            continue;

                        var view = rw.Register();

                        CreateViewChannel?.Send(new() { Instance = view, Name = type.Name });
                    }
                }

                OnInitializeUI?.Invoke();
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

            return 1;
        }

        internal static delegate* unmanaged<string, delegate* unmanaged<ulong, void>, ulong> _createView;

        public static PrismaView CreateView(string htmlPath, Action<PrismaView>? callback = null)
        {
            try
            {
                return _createView(htmlPath, (OnDomReadyCallback)(view => callback?.Invoke(view)));
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma create view failed: {e.Message}");

                return 0;
            }
        }

        private static readonly Dictionary<(ulong view, string funcName), Action<string>> _listners = [];

        internal static delegate* unmanaged<ulong, string, delegate* unmanaged<string, void>, void> _registerJSListener;

        public static void RegisterJSListener(ulong view, string functionName, Action<string> callback)
        {
            try
            {
                var key = (view, functionName);

                _listners[key] = callback;

                _registerJSListener(view, functionName, (JSListenerCallback)((argument) => callback(argument ?? "")));
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma register JS listener failed: {e.StackTrace}");
            }
        }

        internal static delegate* unmanaged<ulong, string, delegate* unmanaged<string, void>, void> _invoke;

        public static void Invoke(ulong view, string script, Action<IntPtr>? callback = null)
        {
            try
            {
                _invoke(view, script, (JSCallback)callback);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma invoke failed: {e.Message}");
            }
        }

        internal static GetBool _hasFocus;

        public static bool HasFocus(ulong view)
        {
            try
            {
                return _hasFocus(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma check HasFocus failed: {e.Message}");

                return false;
            }
        }

        internal static delegate* unmanaged<ulong, bool, bool, bool> _focus;

        public static bool Focus(ulong view, bool pauseGame = false, bool disableFocusMenu = false)
        {
            try
            {
                return _focus(view, pauseGame, disableFocusMenu);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma focus failed: {e.Message}");

                return false;
            }
        }

        internal static VoidInteraction _unfocus;

        public static void Unfocus(ulong view)
        {
            try
            {
                _unfocus(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma unfocus failed: {e.Message}");
            }
        }

        internal static VoidInteraction _show;

        public static void Show(ulong view)
        {
            try
            {
                _show(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma show failed: {e.Message}");
            }
        }

        internal static VoidInteraction _hide;

        public static void Hide(ulong view)
        {
            try
            {
                _hide(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma hide failed: {e.Message}");
            }
        }

        internal static GetBool _isHidden;

        public static bool IsHidden(ulong view)
        {
            try
            {
                return _isHidden(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma check IsHidden failed: {e.Message}");

                return false;
            }
        }

        internal static GetInt _getScrollingPixelSize;

        public static int GetScrollingPixelSize(ulong view)
        {
            try
            {
                return _getScrollingPixelSize(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma get ScrollPixelSize failed: {e.Message}");

                return -1;
            }
        }

        internal static SetInt _setScrollingPixelSize;

        public static void SetScrollingPixelSize(ulong view, int pixelSize)
        {
            try
            {
                _setScrollingPixelSize(view, pixelSize);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma set ScrollingPixelSize failed: {e.Message}");
            }
        }

        internal static GetBool _isValid;

        public static bool IsValid(ulong view)
        {
            try
            {
                return _isValid(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma check IsValid failed: {e.Message}");

                return false;
            }
        }

        internal static VoidInteraction _destory;

        public static void Destory(ulong view)
        {
            try
            {
                _destory(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma destory failed: {e.Message}");
            }
        }

        internal static GetInt _getOrder;

        public static int GetOrder(ulong view)
        {
            try
            {
                return _getOrder(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma get Order failed: {e.Message}");

                return -1;
            }
        }

        internal static SetInt _setOrder;

        public static void SetOrder(ulong view, int order)
        {
            try
            {
                _setOrder(view, order);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma set Order failed: {e.Message}");
            }
        }

        internal static VoidInteraction _createInspectorView;

        public static void CreateInspectorView(ulong view)
        {
            try
            {
                _createInspectorView(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma create inspector view failed: {e.Message}");
            }
        }

        internal static SetBool _setInspectorVisibility;

        public static void SetInspectorVisibility(ulong view, bool visable)
        {
            try
            {
                _setInspectorVisibility(view, visable);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma set InspectorVisibility failed: {e.Message}");
            }
        }

        internal static GetBool _getInspectorVisibility;

        public static bool GetInspectorVisibility(ulong view)
        {
            try
            {
                return _getInspectorVisibility(view);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma get InspectorVisibility failed: {e.Message}");

                return false;
            }
        }

        internal static delegate* unmanaged<ulong, float, float, uint, uint, void> _setInspectorBounds;

        public static void SetInspectorBounds(ulong view, float topLeftX, float topLeftY, uint width, uint height)
        {
            try
            {
                _setInspectorBounds(view, topLeftX, topLeftY, width, height);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma set InspectorBounds failed: {e.Message}");
            }
        }

        internal static delegate* unmanaged<bool> _hasAnyActiveFocus;

        public static bool HasAnyActiveFocus()
        {
            try
            {
                return _hasAnyActiveFocus();
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma check HasAnyActiveFocus failed: {e.Message}");

                return false;
            }
        }

        internal static delegate* unmanaged<ulong, delegate* unmanaged<ConsoleMessageLevel, IntPtr, void>, void> _registerConsoleCallback;

        public static void RegisterConsoleCallback(ulong view, Action<ulong, ConsoleMessageLevel, IntPtr> callback)
        {
            try
            {
                _registerConsoleCallback(view, (ConsoleMessageCallback)callback);
            }
            catch (Exception e)
            {
                Logger.Error($"Prisma register ConsoleCallback failed: {e.Message}");
            }
        }
    }

    public enum ConsoleMessageLevel : byte
    {
        Log = 0,
        Warning,
        Error,
        Debug,
        Info
    }

    public record struct CreateViewManagedArgs(ulong Instance, string Name);

    public record struct CreateViewNativeArgs(ulong Instance, IntPtr Name);

    public class CreateViewChannel : EventChannel<CreateViewManagedArgs, CreateViewNativeArgs>
    {
        public override string EventName => "PrismaCreateView";

        public override CreateViewNativeArgs ManagedToNative(CreateViewManagedArgs args) => new(args.Instance, Marshal.StringToCoTaskMemUTF8(args.Name));

        public override CreateViewManagedArgs NativeToManaged(CreateViewNativeArgs args) => new(args.Instance, Marshal.PtrToStringUTF8(args.Name) ?? "");
    }
}
