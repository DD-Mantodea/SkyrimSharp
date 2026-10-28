using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using unsafe NativeEventHandler = delegate* unmanaged<string, nint, int, void>;

namespace SkyrimSharpLoader.Internal
{
    public unsafe static class EventManager
    {
        internal static delegate* unmanaged<NativeEventHandler, string, void> _register;

        public static bool Register(SkyrimSharpEventHandler handler, string eventName = "")
        {
            if (_register == null || handler == null)
                return false;

            _register((NativeEventHandler)Marshal.GetFunctionPointerForDelegate(handler), eventName);

            return true;
        }

        internal static delegate* unmanaged<NativeEventHandler, string, void> _unregister;

        public static bool Unregister(SkyrimSharpEventHandler handler, string eventName = "")
        {
            if (_unregister == null || handler == null)
                return false;

            _unregister((NativeEventHandler)Marshal.GetFunctionPointerForDelegate(handler), eventName);

            return true;
        }

        internal static NativeEventHandler _send;

        public static bool Send(string eventName, IntPtr args, int sizeBytes)
        {
            if (_send == null)
                return false;

            _send(eventName, args, sizeBytes);

            return true;
        }
    }

    public abstract unsafe class EventChannel<TManagedArgs, TNativeArgs> where TManagedArgs : struct where TNativeArgs : unmanaged
    {
        private Dictionary<int, List<SkyrimSharpEventHandler>> _handlerPairs = [];

        public delegate void EventHandler(string eventName, TManagedArgs args);

        public virtual string EventName => GetType().FullName ?? GetType().Name;

        public virtual void Register(EventHandler handler)
        {
            if (handler == null || EventManager._register == null)
                return;

            var eventHandler = new SkyrimSharpEventHandler((eventName, args, sizeBytes) =>
            {
                var name = eventName ?? "";

                if (sizeBytes != sizeof(TNativeArgs))
                    Logger.Error($"Event {name} error: args size do not equal sizeBytes, size of args is {sizeof(TNativeArgs)}, sizeBytes is {sizeBytes}");

                handler(name, NativeToManaged(GetArgsFromPtr(args)));
            });

            var index = handler.GetHashCode();

            var eventPtr = Marshal.GetFunctionPointerForDelegate(eventHandler);

            if (!_handlerPairs.TryGetValue(index, out var handlers))
            {
                handlers = [];

                _handlerPairs.Add(index, handlers);
            }

            handlers?.Add(eventHandler);

            EventManager._register((NativeEventHandler)eventPtr, EventName);
        }

        public virtual void Unregister(EventHandler handler)
        {
            if (handler == null || EventManager._unregister == null)
                return;

            var index = handler.GetHashCode();

            if (!_handlerPairs.TryGetValue(index, out var handlers))
                return;

            foreach (var h in handlers ?? [])
            {
                var eventPtr = Marshal.GetFunctionPointerForDelegate(h);

                EventManager._unregister((NativeEventHandler)eventPtr, EventName);
            }
        }

        public virtual void Send(TManagedArgs args)
        {
            var nativeArgs = ManagedToNative(args);

            var ptr = NativeMemory.Alloc((nuint)sizeof(TNativeArgs));

            try
            {
                Unsafe.Write(ptr, nativeArgs);

                EventManager.Send(EventName, (nint)ptr, sizeof(TNativeArgs));
            }
            catch (Exception e)
            {
                Logger.Error($"Event {EventName} error: {e.StackTrace}");
            }
            finally
            {
                NativeMemory.Free(ptr);
            }
        }

        public virtual TNativeArgs GetArgsFromPtr(nint ptr) => Unsafe.Read<TNativeArgs>((void*)ptr);

        public virtual TManagedArgs NativeToManaged(TNativeArgs args) => args is TManagedArgs mArgs ? mArgs : default;

        public virtual TNativeArgs ManagedToNative(TManagedArgs args) => args is TNativeArgs nArgs ? nArgs : default;
    }

    public delegate void SkyrimSharpEventHandler(string eventName, IntPtr args, int sizeBytes);
}
