using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct TESGlobal(TESGlobal.Internal* ptr)
        : ITESGlobal, IFromNative<TESGlobal, TESGlobal.Internal>
    {
        public enum Type : byte
        {
            kFloat = (byte)'f',
            kLong = (byte)'l',
            kShort = (byte)'s'
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal TESForm.Internal Base_0;
            internal BSString FormEditorID;
            internal byte Type;
            internal byte pad31;
            internal ushort pad32;
            internal float Value;
        }

        static TESGlobal()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_TESGlobal", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_TESGlobal", 0));
            _vtables.Add("TESGlobal", VTABLES.Get("VTABLE_TESGlobal", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator TESGlobal(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESGlobal instance) => (Internal*)instance.Native.ToPointer();

        public static TESGlobal FromNative(nint ptr) => new((Internal*)ptr);

        public Type ValueType => (Type)((Internal*)Native.ToPointer())->Type;

        public float Value
        {
            get => ((Internal*)Native.ToPointer())->Value;
            set => ((Internal*)Native.ToPointer())->Value = value;
        }
    }

    public static unsafe class TESGlobalExt
    {
        public static nint GetFormEditorID<T>(this T global) where T : ITESGlobal, IFromNative
            => global.Native.CallVirt<nint>(0x32, global.Vtables["TESGlobal"]);

        public static bool SetFormEditorID<T>(this T global, nint a_str) where T : ITESGlobal, IFromNative
            => global.Native.CallVirt<nint, bool>(a_str, 0x33, global.Vtables["TESGlobal"]);
    }

    public unsafe interface ITESGlobal : ITESForm;
}
