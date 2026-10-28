using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSStoryManagerQuestNode(BGSStoryManagerQuestNode.Internal* ptr)
        : IBGSStoryManagerQuestNode, IFromNative<BGSStoryManagerQuestNode, BGSStoryManagerQuestNode.Internal>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal BGSStoryManagerNodeBase.Internal Base_0;
            internal BSTArray<Ptr<TESQuest.Internal>>.Internal Quests;
            internal BSTHashMap<Ptr<TESQuest.Internal>, uint>.Internal PerQuestFlags;
            internal BSTHashMap<Ptr<TESQuest.Internal>, float>.Internal PerQuestHoursUntilReset;
            internal uint NumQuestsToStart;
            internal uint padC4;
            internal BSTArray<float>.Internal ChildrenLastRun;
        }

        static BGSStoryManagerQuestNode()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_BGSStoryManagerQuestNode", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_BGSStoryManagerQuestNode", 0));
            _vtables.Add("BGSStoryManagerTreeForm", VTABLES.Get("VTABLE_BGSStoryManagerQuestNode", 0));
            _vtables.Add("BGSStoryManagerNodeBase", VTABLES.Get("VTABLE_BGSStoryManagerQuestNode", 0));
            _vtables.Add("BGSStoryManagerQuestNode", VTABLES.Get("VTABLE_BGSStoryManagerQuestNode", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator BGSStoryManagerQuestNode(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BGSStoryManagerQuestNode instance) => (Internal*)instance.Native.ToPointer();

        public static BGSStoryManagerQuestNode FromNative(nint ptr) => new((Internal*)ptr);
    }

    public unsafe interface IBGSStoryManagerQuestNode : IBGSStoryManagerNodeBase;
}
