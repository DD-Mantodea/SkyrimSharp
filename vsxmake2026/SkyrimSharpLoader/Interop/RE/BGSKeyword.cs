using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSKeyword(BGSKeyword.Internal* ptr) : IBGSKeyword, IFromNative<BGSKeyword, BGSKeyword.Internal>
    {
        public enum RecordFlags
        {
            kDeleted = 1 << 5,
            kIgnored = 1 << 12
        }

        public struct Internal
        {
            internal TESForm.Internal Base;

            internal BSFixedString FormEditorID;
        }

        static BGSKeyword()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_BGSKeyword", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_BGSKeyword", 0));
            _vtables.Add("BGSKeyword", VTABLES.Get("VTABLE_BGSKeyword", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator BGSKeyword(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BGSKeyword instance) => (Internal*)instance.Native.ToPointer();

        public static BGSKeyword FromNative(nint ptr) => new((Internal*)ptr);
    }

    public interface IBGSKeyword : ITESForm;
}
