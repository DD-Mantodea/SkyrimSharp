namespace SkyrimSharpLoader.Interop.Interfaces
{
    public unsafe interface IFromNative
    {
        nint Native { get; }
    }

    public unsafe interface IFromNative<TManaged> : IFromNative where TManaged : IFromNative<TManaged>
    {
        public abstract static TManaged FromNative(nint ptr);
    }

    public unsafe interface IFromNative<TManaged, TNative> : IFromNative<TManaged> where TManaged : IFromNative<TManaged, TNative> where TNative : unmanaged
    {
        public abstract static implicit operator TManaged(TNative* ptr);

        public abstract static implicit operator TNative*(TManaged instance);
    }

    public static class IFromNativeExt
    {
        public static bool TryAs<T, TInterface>(this IFromNative ifn, out T? result) where T : class, IFromNative<T>, TInterface
        {
            result = null;

            if (ifn == null || ifn.Native == 0)
                return false;

            if (ifn is T t)
            {
                result = t;

                return true;
            }

            if (!FromNativeInterfaceCheck<TInterface>.IsInterface || ifn is not TInterface)
                return false;

            result = T.FromNative(ifn.Native);

            return true;
        }

        public static T? As<T>(this IFromNative ifn) where T : class, IFromNative<T>
        {
            if (ifn == null || ifn.Native == 0)
                return default;

            if (ifn is T t)
                return t;

            return T.FromNative(ifn.Native);
        }
    }

    internal static class FromNativeInterfaceCheck<T>
    {
        internal static readonly bool IsInterface = typeof(T).IsInterface;
    }
}
