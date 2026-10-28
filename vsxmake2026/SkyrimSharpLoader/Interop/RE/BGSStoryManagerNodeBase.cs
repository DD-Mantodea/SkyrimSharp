using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSStoryManagerNodeBase(BGSStoryManagerNodeBase.Internal* ptr)
        : IBGSStoryManagerNodeBase, IFromNative<BGSStoryManagerNodeBase, BGSStoryManagerNodeBase.Internal>
    {
        public struct Flags
        {
            internal ushort NodeFlags;
            internal ushort QuestFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal BGSStoryManagerTreeForm.Internal Base_0;
            internal BGSStoryManagerNodeBase.Internal* Parent;
            internal BGSStoryManagerNodeBase.Internal* PreviousSibling;
            internal uint MaxQuests;
            internal Flags Flags;
            internal TESCondition Conditions;
        }

        static BGSStoryManagerNodeBase()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_BGSStoryManagerNodeBase", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_BGSStoryManagerNodeBase", 0));
            _vtables.Add("BGSStoryManagerTreeForm", VTABLES.Get("VTABLE_BGSStoryManagerNodeBase", 0));
            _vtables.Add("BGSStoryManagerNodeBase", VTABLES.Get("VTABLE_BGSStoryManagerNodeBase", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator BGSStoryManagerNodeBase(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BGSStoryManagerNodeBase instance) => (Internal*)instance.Native.ToPointer();

        public static BGSStoryManagerNodeBase FromNative(nint ptr) => new((Internal*)ptr);

        public BGSStoryManagerNodeBase.Internal* Parent => ((Internal*)Native.ToPointer())->Parent;

        public uint MaxQuests => ((Internal*)Native.ToPointer())->MaxQuests;
    }

    public static unsafe class BGSStoryManagerNodeBaseExt
    {
        public static TESCondition* QConditions<T>(this T node) where T : IBGSStoryManagerNodeBase, IFromNative
            => (TESCondition*)node.Native.CallVirt<nint>(0x3D, node.Vtables["BGSStoryManagerNodeBase"]);
    }

    public unsafe interface IBGSStoryManagerNodeBase : IBGSStoryManagerTreeForm;
}
