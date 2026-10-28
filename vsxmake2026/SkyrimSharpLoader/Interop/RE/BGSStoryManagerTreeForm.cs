using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSStoryManagerTreeForm(BGSStoryManagerTreeForm.Internal* ptr)
        : IBGSStoryManagerTreeForm, IFromNative<BGSStoryManagerTreeForm, BGSStoryManagerTreeForm.Internal>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal TESForm.Internal Base_0;
            internal uint LastVisitorID;
            internal uint pad24;
        }

        static BGSStoryManagerTreeForm()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_BGSStoryManagerTreeForm", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_BGSStoryManagerTreeForm", 0));
            _vtables.Add("BGSStoryManagerTreeForm", VTABLES.Get("VTABLE_BGSStoryManagerTreeForm", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator BGSStoryManagerTreeForm(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BGSStoryManagerTreeForm instance) => (Internal*)instance.Native.ToPointer();

        public static BGSStoryManagerTreeForm FromNative(nint ptr) => new((Internal*)ptr);

        public uint LastVisitorID
        {
            get => ((Internal*)Native.ToPointer())->LastVisitorID;
            set => ((Internal*)Native.ToPointer())->LastVisitorID = value;
        }
    }

    public static unsafe class BGSStoryManagerTreeFormExt
    {
        public static uint QChildCount<T>(this T form) where T : IBGSStoryManagerTreeForm, IFromNative
            => form.Native.CallVirt<uint>(0x3B, form.Vtables["BGSStoryManagerTreeForm"]);

        public static BGSStoryManagerTreeForm GetChild<T>(this T form, uint a_idx) where T : IBGSStoryManagerTreeForm, IFromNative
            => (BGSStoryManagerTreeForm.Internal*)form.Native.CallVirt<uint, nint>(a_idx, 0x3C, form.Vtables["BGSStoryManagerTreeForm"]);
    }

    public unsafe interface IBGSStoryManagerTreeForm : ITESForm;
}
