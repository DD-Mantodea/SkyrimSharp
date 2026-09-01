using System.Runtime.CompilerServices;

namespace SkyrimSharpLoader.Interop.Extensions
{
    public static unsafe class InternalExt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallVoidVirt(this nint t, nint index, void** vtable)
        {
            var ptr = (void*)t;

            ((delegate* unmanaged<void*, void>)vtable[index])(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallVoidVirt<TArg>(this nint t, TArg arg, nint index, void** vtable) where TArg : unmanaged
        {
            var ptr = (void*)t;

            ((delegate* unmanaged<void*, TArg, void>)vtable[index])(ptr, arg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<TRet>(this nint t, nint index, void** vtable)
        {
            var ptr = (void*)t;

            return ((delegate* unmanaged<void*, TRet>)vtable[index])(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<TArg, TRet>(this nint t, TArg arg, nint index, void** vtable) where TArg : unmanaged
        {
            var ptr = (void*)t;

            return ((delegate* unmanaged<void*, TArg, TRet>)vtable[index])(ptr, arg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<TArg1, TArg2, TRet>(this nint t, TArg1 arg1, TArg2 arg2, nint index, void** vtable) where TArg1 : unmanaged where TArg2 : unmanaged
        {
            var ptr = (void*)t;

            return ((delegate* unmanaged<void*, TArg1, TArg2, TRet>)vtable[index])(ptr, arg1, arg2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<TArg1, TArg2, TArg3, TRet>(this nint t, TArg1 arg1, TArg2 arg2, TArg3 arg3, nint index, void** vtable) where TArg1 : unmanaged where TArg2 : unmanaged where TArg3 : unmanaged
        {
            var ptr = (void*)t;

            return ((delegate* unmanaged<void*, TArg1, TArg2, TArg3, TRet>)vtable[index])(ptr, arg1, arg2, arg3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<TArg1, TArg2, TArg3, TArg4, TRet>(this nint t, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, nint index, void** vtable)
            where TArg1 : unmanaged
            where TArg2 : unmanaged
            where TArg3 : unmanaged
            where TArg4 : unmanaged
        {
            var ptr = (void*)t;

            return ((delegate* unmanaged<void*, TArg1, TArg2, TArg3, TArg4, TRet>)vtable[index])(ptr, arg1, arg2, arg3, arg4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<TArg1, TArg2, TArg3, TArg4, TArg5, TRet>(this nint t, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, nint index, void** vtable)
            where TArg1 : unmanaged
            where TArg2 : unmanaged
            where TArg3 : unmanaged
            where TArg4 : unmanaged
            where TArg5 : unmanaged
        {
            var ptr = (void*)t;

            return ((delegate* unmanaged<void*, TArg1, TArg2, TArg3, TArg4, TArg5, TRet>)vtable[index])(ptr, arg1, arg2, arg3, arg4, arg5);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallVoidVirt<T>(this ref T t, nint index, void** vtable) where T : unmanaged
        {
            var ptr = Unsafe.AsPointer(ref t);

            ((delegate* unmanaged<void*, void>)vtable[index])(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallVoidVirt<T, TArg>(this ref T t, TArg arg, nint index, void** vtable) where T : unmanaged where TArg : unmanaged
        {
            var ptr = Unsafe.AsPointer(ref t);

            ((delegate* unmanaged<void*, TArg, void>)vtable[index])(ptr, arg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<T, TRet>(this ref T t, nint index, void** vtable) where T : unmanaged
        {
            var ptr = Unsafe.AsPointer(ref t);

            return ((delegate* unmanaged<void*, TRet>)vtable[index])(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<T, TArg, TRet>(this ref T t, TArg arg, nint index, void** vtable) where T : unmanaged where TArg : unmanaged
        {
            var ptr = Unsafe.AsPointer(ref t);

            return ((delegate* unmanaged<void*, TArg, TRet>)vtable[index])(ptr, arg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<T, TArg1, TArg2, TRet>(this ref T t, TArg1 arg1, TArg2 arg2, nint index, void** vtable) where T : unmanaged where TArg1 : unmanaged where TArg2 : unmanaged
        {
            var ptr = Unsafe.AsPointer(ref t);

            return ((delegate* unmanaged<void*, TArg1, TArg2, TRet>)vtable[index])(ptr, arg1, arg2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<T, TArg1, TArg2, TArg3, TRet>(this ref T t, TArg1 arg1, TArg2 arg2, TArg3 arg3, nint index, void** vtable) where T : unmanaged where TArg1 : unmanaged where TArg2 : unmanaged where TArg3 : unmanaged
        {
            var ptr = Unsafe.AsPointer(ref t);

            return ((delegate* unmanaged<void*, TArg1, TArg2, TArg3, TRet>)vtable[index])(ptr, arg1, arg2, arg3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<T, TArg1, TArg2, TArg3, TArg4, TRet>(this ref T t, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, nint index, void** vtable)
            where T : unmanaged
            where TArg1 : unmanaged
            where TArg2 : unmanaged
            where TArg3 : unmanaged
            where TArg4 : unmanaged
        {
            var ptr = Unsafe.AsPointer(ref t);

            return ((delegate* unmanaged<void*, TArg1, TArg2, TArg3, TArg4, TRet>)vtable[index])(ptr, arg1, arg2, arg3, arg4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TRet CallVirt<T, TArg1, TArg2, TArg3, TArg4, TArg5, TRet>(this ref T t, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, nint index, void** vtable)
            where T : unmanaged
            where TArg1 : unmanaged
            where TArg2 : unmanaged
            where TArg3 : unmanaged
            where TArg4 : unmanaged
            where TArg5 : unmanaged
        {
            var ptr = Unsafe.AsPointer(ref t);

            return ((delegate* unmanaged<void*, TArg1, TArg2, TArg3, TArg4, TArg5, TRet>)vtable[index])(ptr, arg1, arg2, arg3, arg4, arg5);
        }
    }
}
