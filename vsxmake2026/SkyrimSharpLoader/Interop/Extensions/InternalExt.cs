using System.Runtime.CompilerServices;

namespace SkyrimSharpLoader.Interop.Extensions
{
    public static unsafe class InternalExt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void** Vtable<T>(this ref T t, int offset) where T : unmanaged
        {
            ref byte byteRef = ref Unsafe.As<T, byte>(ref t);

            if (offset > 0)
                byteRef = ref Unsafe.AddByteOffset(ref byteRef, offset);

            nint ptr = Unsafe.As<byte, nint>(ref byteRef);

            return (void**)ptr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallVoidVirt<TSelf>(this ref TSelf t, nint index, int offset = 0) where TSelf : unmanaged
        {
            TSelf* ptr = (TSelf*)Unsafe.AsPointer(ref t);

            var vtable = t.Vtable(offset);

            ((delegate* unmanaged<TSelf*, void>)vtable[index])(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallVoidVirt<TSelf, TArg>(this ref TSelf t, TArg arg, nint index, int offset = 0) where TSelf : unmanaged where TArg : unmanaged
        {
            TSelf* ptr = (TSelf*)Unsafe.AsPointer(ref t);

            var vtable = t.Vtable(offset);

            ((delegate* unmanaged<TSelf*, TArg, void>)vtable[index])(ptr, arg);
        }

        public static TRet CallVirt<TSelf, TRet>(this ref TSelf t, nint index, int offset = 0) where TSelf : unmanaged
        {
            TSelf* ptr = (TSelf*)Unsafe.AsPointer(ref t);

            var vtable = t.Vtable(offset);

            return ((delegate* unmanaged<TSelf*, TRet>)vtable[index])(ptr);
        }

        public static TRet CallVirt<TSelf, TArg, TRet>(this ref TSelf t, TArg arg, nint index, int offset = 0) where TSelf : unmanaged where TArg : unmanaged
        {
            TSelf* ptr = (TSelf*)Unsafe.AsPointer(ref t);

            var vtable = t.Vtable(offset);

            return ((delegate* unmanaged<TSelf*, TArg, TRet>)vtable[index])(ptr, arg);
        }

        public static TRet CallVirt<TSelf, TArg1, TArg2, TRet>(this ref TSelf t, TArg1 arg1, TArg2 arg2, nint index, int offset = 0) where TSelf : unmanaged where TArg1 : unmanaged where TArg2 : unmanaged
        {
            TSelf* ptr = (TSelf*)Unsafe.AsPointer(ref t);

            var vtable = t.Vtable(offset);

            return ((delegate* unmanaged<TSelf*, TArg1, TArg2, TRet>)vtable[index])(ptr, arg1, arg2);
        }

        public static TRet CallVirt<TSelf, TArg1, TArg2, TArg3, TRet>(this ref TSelf t, TArg1 arg1, TArg2 arg2, TArg3 arg3, nint index, int offset = 0) where TSelf : unmanaged where TArg1 : unmanaged where TArg2 : unmanaged where TArg3 : unmanaged
        {
            TSelf* ptr = (TSelf*)Unsafe.AsPointer(ref t);

            var vtable = t.Vtable(offset);

            return ((delegate* unmanaged<TSelf*, TArg1, TArg2, TArg3, TRet>)vtable[index])(ptr, arg1, arg2, arg3);
        }

        public static TRet CallVirt<TSelf, TArg1, TArg2, TArg3, TArg4, TRet>(this ref TSelf t, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, nint index, int offset = 0) where TSelf : unmanaged
            where TArg1 : unmanaged
            where TArg2 : unmanaged
            where TArg3 : unmanaged
            where TArg4 : unmanaged
        {
            TSelf* ptr = (TSelf*)Unsafe.AsPointer(ref t);

            var vtable = t.Vtable(offset);

            return ((delegate* unmanaged<TSelf*, TArg1, TArg2, TArg3, TArg4, TRet>)vtable[index])(ptr, arg1, arg2, arg3, arg4);
        }

        public static TRet CallVirt<TSelf, TArg1, TArg2, TArg3, TArg4, TArg5, TRet>(this ref TSelf t, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, nint index, int offset = 0) where TSelf : unmanaged
            where TArg1 : unmanaged
            where TArg2 : unmanaged
            where TArg3 : unmanaged
            where TArg4 : unmanaged
            where TArg5 : unmanaged
        {
            TSelf* ptr = (TSelf*)Unsafe.AsPointer(ref t);

            var vtable = t.Vtable(offset);

            return ((delegate* unmanaged<TSelf*, TArg1, TArg2, TArg3, TArg4, TArg5, TRet>)vtable[index])(ptr, arg1, arg2, arg3, arg4, arg5);
        }
    }
}
