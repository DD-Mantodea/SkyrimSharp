using SkyrimSharpLoader.Internal;
using SkyrimSharpLoader.Interop.Interfaces;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct TESObjectREFR(TESObjectREFR.Internal* ptr) : ITESObjectREFR, IFromNative<TESObjectREFR, TESObjectREFR.Internal>
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x88)]
        public struct Internal
        {
            internal TESForm.Internal Base_0;

            internal BSHandleRefObject.Internal Base_1;

            internal BSTEventSink<BSAnimationGraphEvent.Internal>.Internal Base_2;

            internal IAnimationGraphManagerHolder.Internal Base_3;

            internal OBJ_REFR Data;

            internal void* ParentCell;

            internal void* LoadedData;

            internal ExtraDataList* ExtraList;

            internal bool Activate(Internal* a_targetRef, Internal* a_activatorRef, byte a_arg3, TESBoundObject.Internal* a_object, int a_targetCount)
                => Base_0.Activate(a_targetRef, a_activatorRef, a_arg3, a_object, a_targetCount);
        }

        public nint Native { get; } = new(ptr);

        public static implicit operator TESObjectREFR(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESObjectREFR instance) => (Internal*)instance.Native.ToPointer();

        public static TESObjectREFR FromNative(nint ptr) => new((Internal*)ptr);

        public OBJ_REFR Data
        {
            get => ((Internal*)Native.ToPointer())->Data;
            set => ((Internal*)Native.ToPointer())->Data = value;
        }
    }

    public static unsafe class TESObjectREFRExt
    {
        private static delegate* unmanaged<nint, string> _nativeGetDisplayFullName;

        public static string GetDisplayFullName(this ITESObjectREFR refr)
        {
            if (_nativeGetDisplayFullName == null)
                _nativeGetDisplayFullName = (delegate* unmanaged<nint, string>)AddressLib.GetAddr(19781);

            if (_nativeGetDisplayFullName == null || refr is not IFromNative fn)
                return "";
            else
                return _nativeGetDisplayFullName(fn.Native) ?? "";
        }

        private static delegate* unmanaged<nint, nint, byte, nint, int, bool, bool> _nativeActivateRef;

        public static bool ActivateRef(this ITESObjectREFR refr, TESObjectREFR activator, byte arg2, TESBoundObject obj, int count, bool defaultPorcessingOnly = false)
        {
            if (_nativeActivateRef == null)
                _nativeActivateRef = (delegate* unmanaged<nint, nint, byte, nint, int, bool, bool>)AddressLib.GetAddr(19796);

            if (_nativeActivateRef == null || refr is not IFromNative fn)
                return false;
            else
                return _nativeActivateRef(fn.Native, activator.Native, arg2, obj.Native, count, defaultPorcessingOnly);
        }

        public static TESBoundObject GetBaseObject(this ITESObjectREFR refr)
        {
            if (refr is not IFromNative fn)
                return null;
            else
            {
                var objRefr = (TESObjectREFR.Internal*)fn.Native;

                return objRefr->Data.ObjectReference;
            }
        }
    }

    public unsafe interface ITESObjectREFR :
        ITESForm,
        IBSHandleRefObject,
        IBSTEventSink<BSAnimationGraphEvent.Internal>,
        IIAnimationGraphManagerHolder;

    public unsafe struct OBJ_REFR
    {
        public TESBoundObject.Internal* ObjectReference;

        public NiPoint3 Angle;

        public NiPoint3 Location;
    }
}
