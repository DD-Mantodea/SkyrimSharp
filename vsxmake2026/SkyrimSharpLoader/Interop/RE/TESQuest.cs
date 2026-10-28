using SkyrimSharpLoader.Internal;
using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;
using System.Text;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct TESQuest(TESQuest.Internal* ptr)
        : ITESQuest, IFromNative<TESQuest, TESQuest.Internal>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal BGSStoryManagerTreeForm.Internal Base_0;
            internal TESFullName.Internal Base_1;

            internal BSTArray<Ptr<BGSQuestInstanceText>>.Internal InstanceData;
            internal uint CurrentInstanceID;
            internal uint pad054;
            internal BSTArray<Ptr<BGSBaseAlias.Internal>>.Internal Aliases;
            internal BSTHashMap<uint, ObjectRefHandle>.Internal RefAliasMap;
            internal BSTHashMap<nint, nint>.Internal unk0A0;
            internal BSReadWriteLock AliasAccessLock;
            internal QUEST_DATA Data;
            internal QuestEvent EventID;
            internal uint pad0E4;
            internal BSSimpleList<Ptr<TESQuestStage>>* ExecutedStages;
            internal BSSimpleList<Ptr<TESQuestStage>>* WaitingStages;
            internal BSSimpleList<Ptr<BGSQuestObjective>> Objectives;
            internal TESCondition ObjConditions;
            internal TESCondition StoryManagerConditions;

            internal BSTHashMap<Ptr<BGSDialogueBranch.Internal>, Ptr<BSTArray<Ptr<TESTopic.Internal>>>>.Internal BranchedDialogue0;
            internal BSTHashMap<Ptr<BGSDialogueBranch.Internal>, Ptr<BSTArray<Ptr<TESTopic.Internal>>>>.Internal BranchedDialogue1;

            internal BSTArray<Ptr<TESTopic.Internal>>.Internal Topic0;
            internal BSTArray<Ptr<TESTopic.Internal>>.Internal Topic1;
            internal BSTArray<Ptr<TESTopic.Internal>>.Internal Topic2;
            internal BSTArray<Ptr<TESTopic.Internal>>.Internal Topic3;
            internal BSTArray<Ptr<TESTopic.Internal>>.Internal Topic4;
            internal BSTArray<Ptr<TESTopic.Internal>>.Internal Topic5;

            internal BSTArray<Ptr<BGSScene.Internal>>.Internal Scenes;
            internal BSTArray<Ptr<TESGlobal.Internal>>* TextGlobals;
            internal ushort CurrentStage;
            internal bool AlreadyRun;
            internal byte pad22B;
            internal uint pad22C;
            internal BSString FormEditorID;
            internal BGSStoryEvent* StartEventData;
            internal QueuedPromoteQuestTask.Internal* PromoteTask;
            internal BSTArray<ObjectRefHandle>.Internal PromotedRefs;
        }

        static TESQuest()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_TESQuest", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_TESQuest", 0));
            _vtables.Add("BGSStoryManagerTreeForm", VTABLES.Get("VTABLE_TESQuest", 0));
            _vtables.Add("TESQuest", VTABLES.Get("VTABLE_TESQuest", 0));
            _vtables.Add("TESFullName", VTABLES.Get("VTABLE_TESQuest", 1));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator TESQuest(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESQuest instance) => (Internal*)instance.Native.ToPointer();

        public static TESQuest FromNative(nint ptr) => new((Internal*)ptr);

        public ushort CurrentStage
        {
            get => ((Internal*)Native.ToPointer())->CurrentStage;
            set => ((Internal*)Native.ToPointer())->CurrentStage = value;
        }

        public bool AlreadyRun
        {
            get => ((Internal*)Native.ToPointer())->AlreadyRun;
            set => ((Internal*)Native.ToPointer())->AlreadyRun = value;
        }

        public QUEST_DATA Data => ((Internal*)Native.ToPointer())->Data;

        public QUEST_DATA.Type QuestType => (QUEST_DATA.Type)((Internal*)Native.ToPointer())->Data.QuestType;

        public QuestEvent EventID => ((Internal*)Native.ToPointer())->EventID;

        public bool IsRunning => (Data.Flags & QuestFlag.kActive) != 0;

        public bool IsCompleted => (Data.Flags & QuestFlag.kCompleted) != 0;

        public bool IsEnabled => (Data.Flags & QuestFlag.kEnabled) != 0;

        public bool StartsEnabled => (Data.Flags & QuestFlag.kStartsEnabled) != 0;

        public float QuestDelayTime => ((Internal*)Native.ToPointer())->Data.QuestDelayTime;

        private static delegate* unmanaged<Internal*, ref bool, bool, bool> _ensureQuestStarted;

        public bool EnsureQuestStarted(ref bool result, bool startNow)
        {
            if (_ensureQuestStarted == null)
                _ensureQuestStarted = (delegate* unmanaged<Internal*, ref bool, bool, bool>)AddressLib.GetAddr(25003);

            if (_ensureQuestStarted == null)
                return false;
            else
                return _ensureQuestStarted(this, ref result, startNow);
        }

        private static delegate* unmanaged<Internal*, ushort, bool> _setStage;

        public bool SetStage(ushort stage)
        {
           if (!IsEnabled && EventID != QuestEvent.kNone)
                return false;

            bool willStart = false;

            if (!EnsureQuestStarted(ref willStart, false))
                return false;

            if (willStart)
                return true;

            if (_setStage == null)
                _setStage = (delegate* unmanaged<Internal*, ushort, bool>)AddressLib.GetAddr(25004);

            if (_setStage == null)
                return false;
            else
                return _setStage(this, stage);
        }
    }

    public static unsafe class TESQuestExt
    {
        public static string GetFormEditorID<T>(this T quest) where T : ITESQuest, IFromNative
            => Marshal.PtrToStringUTF8(quest.Native.CallVirt<nint>(0x32, quest.Vtables["TESQuest"])) ?? "";

        public static bool SetFormEditorID<T>(this T quest, string a_str) where T : ITESQuest, IFromNative
        {
            var bytes = Encoding.UTF8.GetBytes(a_str + '\0');

            fixed (byte* p = bytes)
                return quest.Native.CallVirt<nint, bool>((nint)p, 0x33, quest.Vtables["TESQuest"]);
        }

        public static uint QChildCount<T>(this T quest) where T : ITESQuest, IFromNative
            => quest.Native.CallVirt<uint>(0x3B, quest.Vtables["TESQuest"]);

        public static TESCondition* QConditions<T>(this T quest) where T : ITESQuest, IFromNative
            => (TESCondition*)quest.Native.CallVirt<nint>(0x3D, quest.Vtables["TESQuest"]);

        public static uint GetFullNameLength<T>(this T quest) where T : ITESQuest, IFromNative
            => quest.Native.CallVirt<uint>(0x04, quest.Vtables["TESFullName"]);

        public static string GetFullName<T>(this T quest) where T : ITESQuest, IFromNative
            => Marshal.PtrToStringUTF8(quest.Native.CallVirt<nint>(0x05, quest.Vtables["TESFullName"])) ?? "";
    }

    public unsafe interface ITESQuest : IBGSStoryManagerTreeForm, ITESFullName;
}
