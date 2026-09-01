using SkyrimSharpLoader.Internal;
using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
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

            internal ExtraDataList ExtraList;

            internal ulong unk88;

            internal ushort RefScale;

            internal byte ModelState;

            internal bool PreDestroyed;

            internal uint pad94;
        }

        static TESObjectREFR()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_TESObjectREFR", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_TESObjectREFR", 0));
            _vtables.Add("TESObjectREFR", VTABLES.Get("VTABLE_TESObjectREFR", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

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

        public static string GetDisplayFullName<T>(this T refr) where T : ITESObjectREFR, IFromNative
        {
            if (_nativeGetDisplayFullName == null)
                _nativeGetDisplayFullName = (delegate* unmanaged<nint, string>)AddressLib.GetAddr(19781);

            if (_nativeGetDisplayFullName == null)
                return "";
            else
                return _nativeGetDisplayFullName(refr.Native) ?? "";
        }

        private static delegate* unmanaged<nint, nint, byte, nint, int, bool, bool> _nativeActivateRef;

        public static bool ActivateRef<T>(this T refr, ITESObjectREFR activator, byte arg2, ITESBoundObject obj, int count, bool defaultPorcessingOnly = false) where T : ITESObjectREFR, IFromNative
        {
            if (_nativeActivateRef == null)
                _nativeActivateRef = (delegate* unmanaged<nint, nint, byte, nint, int, bool, bool>)AddressLib.GetAddr(19796);

            if (_nativeActivateRef == null)
                return false;
            else
                return _nativeActivateRef(refr.Native, activator.Native, arg2, obj.Native, count, defaultPorcessingOnly);
        }

        public static TESBoundObject GetBaseObject<T>(this T refr) where T : ITESObjectREFR, IFromNative
        {
            var objRefr = (TESObjectREFR.Internal*)refr.Native;

            return objRefr->Data.ObjectReference;
        }

        public static NiAVObject Get3D1<T>(this T refr, bool a_firstPerson) where T : ITESObjectREFR, IFromNative
            => new(refr.Native.CallVirt<bool, Ptr<NiAVObject.Internal>>(a_firstPerson, 0x6F, refr.Vtables["TESObjectREFR"]));
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
