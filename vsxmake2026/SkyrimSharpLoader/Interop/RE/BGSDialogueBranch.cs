using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSDialogueBranch(BGSDialogueBranch.Internal* ptr)
        : IBGSDialogueBranch, IFromNative<BGSDialogueBranch, BGSDialogueBranch.Internal>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal TESForm.Internal Base_0;
            internal uint Flags;
            internal uint pad24;
            internal TESQuest.Internal* Quest;
            internal TESTopic.Internal* StartingTopic;
            internal DIALOGUE_TYPE Type;
            internal uint pad3C;
        }

        static BGSDialogueBranch()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_BGSDialogueBranch", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_BGSDialogueBranch", 0));
            _vtables.Add("BGSDialogueBranch", VTABLES.Get("VTABLE_BGSDialogueBranch", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator BGSDialogueBranch(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BGSDialogueBranch instance) => (Internal*)instance.Native.ToPointer();

        public static BGSDialogueBranch FromNative(nint ptr) => new((Internal*)ptr);

        public TESQuest.Internal* Quest => ((Internal*)Native.ToPointer())->Quest;

        public TESTopic.Internal* StartingTopic => ((Internal*)Native.ToPointer())->StartingTopic;

        public DIALOGUE_TYPE Type => ((Internal*)Native.ToPointer())->Type;

        public bool IsTopLevel => ((((Internal*)Native.ToPointer())->Flags >> 0) & 1) != 0;

        public bool IsBlocking => ((((Internal*)Native.ToPointer())->Flags >> 1) & 1) != 0;

        public bool IsExclusive => ((((Internal*)Native.ToPointer())->Flags >> 2) & 1) != 0;
    }

    public static unsafe class BGSDialogueBranchExt
    {
        public static bool IsTopLevelBranch<T>(this T branch) where T : IBGSDialogueBranch, IFromNative
            => ((((BGSDialogueBranch.Internal*)branch.Native)->Flags >> 0) & 1) != 0;

        public static bool IsBlocking<T>(this T branch) where T : IBGSDialogueBranch, IFromNative
            => ((((BGSDialogueBranch.Internal*)branch.Native)->Flags >> 1) & 1) != 0;

        public static bool IsExclusive<T>(this T branch) where T : IBGSDialogueBranch, IFromNative
            => ((((BGSDialogueBranch.Internal*)branch.Native)->Flags >> 2) & 1) != 0;
    }

    public unsafe interface IBGSDialogueBranch : ITESForm;
}
