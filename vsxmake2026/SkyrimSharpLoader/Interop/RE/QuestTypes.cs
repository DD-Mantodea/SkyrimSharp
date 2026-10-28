using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public enum DIALOGUE_TYPE
    {
        kPlayerDialogue = 0,
        kCommandDialogue = 1,
        kBranchedTotal = 2,
        kSceneDialogue = 2,
        kCombat = 3,
        kFavors = 4,
        kDetection = 5,
        kService = 6,
        kMiscellaneous = 7,
        kTotal = 8
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DIALOGUE_DATA
    {
        public enum TopicFlag : byte
        {
            kNone = 0,
            kDoAllBeforeRepeating = 1
        }

        public enum Subtype : ushort
        {
            kCustom = 0,
            kForceGreet = 1,
            kRumors = 2,
            kUnk3 = 3,  // custom?
            kIntimidate = 4,
            kFlatter = 5,
            kBribe = 6,
            kAskGift = 7,
            kGift = 8,
            kAskFavor = 9,
            kFavor = 10,
            kShowRelationships = 11,
            kFollow = 12,
            kReject = 13,
            kScene = 14,
            kShow = 15,
            kAgree = 16,
            kRefuse = 17,
            kExitFavorState = 18,
            kMoralRefusal = 19,
            kFlyingMountLand = 20,
            kFlyingMountCancelLand = 21,
            kFlyingMountAcceptTarget = 22,
            kFlyingMountRejectTarget = 23,
            kFlyingMountNoTarget = 24,
            kFlyingMountDestinationReached = 25,
            kAttack = 26,
            kPowerAttack = 27,
            kBash = 28,
            kHit = 29,
            kFlee = 30,
            kBleedout = 31,
            kAvoidThreat = 32,
            kDeath = 33,
            kGroupStrategy = 34,
            kBlock = 35,
            kTaunt = 36,
            kAllyKilled = 37,
            kSteal = 38,
            kYield = 39,
            kAcceptYield = 40,
            kPickpocketCombat = 41,
            kAssault = 42,
            kMurder = 43,
            kAssaultNPC = 44,
            kMurderNPC = 45,
            kPickpocketNPC = 46,
            kStealFromNPC = 47,
            kTrespassAgainstNPC = 48,
            kTrespass = 49,
            kWereTransformCrime = 50,
            kVoicePowerStartShort = 51,
            kVoicePowerStartLong = 52,
            kVoicePowerEndShort = 53,
            kVoicePowerEndLong = 54,
            kAlertIdle = 55,
            kLostIdle = 56,
            kNormalToAlert = 57,
            kAlertToCombat = 58,
            kNormalToCombat = 59,
            kAlertToNormal = 60,
            kCombatToNormal = 61,
            kCombatToLost = 62,
            kLostToNormal = 63,
            kLostToCombat = 64,
            kDetectFriendDie = 65,
            kServiceRefusal = 66,
            kRepair = 67,
            kTravel = 68,
            kTraining = 69,
            kBarterExit = 70,
            kRepairExit = 71,
            kRecharge = 72,
            kRechargeExit = 73,
            kTrainingExit = 74,
            kObserveCombat = 75,
            kNoticeCorpse = 76,
            kTimeToGo = 77,
            kGoodBye = 78,
            kHello = 79,
            kSwingMeleeWeapon = 80,
            kShootBow = 81,
            kZKeyObject = 82,
            kJump = 83,
            kKnockOverObject = 84,
            kDestroyObject = 85,
            kStandonFurniture = 86,
            kLockedObject = 87,
            kPickpocketTopic = 88,
            kPursueIdleTopic = 89,
            kSharedInfo = 90,
            kPlayerCastProjectileSpell = 91,
            kPlayerCastSelfSpell = 92,
            kPlayerShout = 93,
            kIdle = 94,
            kEnterSprintBreath = 95,
            kEnterBowZoomBreath = 96,
            kExitBowZoomBreath = 97,
            kActorCollidewithActor = 98,
            kPlayerinIronSights = 99,
            kOutofBreath = 100,
            kCombatGrunt = 101,
            kLeaveWaterBreath = 102
        }

        internal byte TopicFlags;
        internal byte Type;
        internal ushort SubtypeValue;
    }

    public enum QuestEvent : int
    {
        kNone = -1,  // NONE
        kKillActor = 0,                                               // KILL
        kAssaultActor = 1,                                            // ASSU
        kChangeLocation = 2,                                          // CLOC
        kScript = 3,                                                  // SCPT
        kActorDialogue = 4,                                           // ADIA
        kActorHello = 5,                                              // AHEL
        kActivateActor = 6,                                           // AFAV
        kPlayerAddItem = 7,                                           // AIPL
        kPlayerRemoveItem = 8,                                        // REMP
        kCraftItem = 9,                                               // CRFT
        kPickLock = 10,                                               // LOCK
        kInfection = 11,                                              // INFC
        kCure = 12,                                                   // CURE
        kNewVoicePower = 13,                                          // NVPE
        kDeadBody = 14,                                               // DEAD
        kSkillIncrease = 15,                                          // SKIL
        kIncreaseLevel = 16,                                          // LEVL
        kChangeRelationshipRank = 17,                                 // CHBR
        kIntimidateNPC = 18,                                          // INTM
        kBribeNPC = 19,                                               // BRIB
        kFlatterNPC = 20,                                             // FLAT
        kPlayerGetsFavor = 21,                                        // PRFV
        kPayFine = 22,                                                // PFIN
        kJail = 23,                                                   // JAIL
        kServedTime = 24,                                             // STIJ
        kEscapeJail = 25,                                             // ESIA
        kTrespass = 26,                                               // TRES
        kCrimeGold = 27,                                              // ADCR
        kArrest = 28,                                                 // ARRT
        kCastMagic = 29                                               // CAST
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct QUEST_DATA
    {
        public enum Type : byte
        {
            kNone = 0,
            kMainQuest = 1,
            kMagesGuild = 2,
            kThievesGuild = 3,
            kDarkBrotherhood = 4,
            kCompanionsQuest = 5,
            kMiscellaneous = 6,
            kDaedric = 7,
            kSideQuest = 8,
            kCivilWar = 9,
            kDLC01_Vampire = 10,
            kDLC02_Dragonborn = 11
        }

        internal float QuestDelayTime;
        internal QuestFlag Flags;
        internal sbyte Priority;
        internal byte QuestType;
    }

    [Flags]
    public enum QuestFlag : ushort
    {
        kStopStart = unchecked((ushort)-1), 
        kNone = 0, 
        kEnabled = 1 << 0, 
        kCompleted = 1 << 1,
        kAddIdleToHello = 1 << 2, 
        kAllowRepeatStages = 1 << 3, 
        kStartsEnabled = 1 << 4,
        kDisplayedInHUD = 1 << 5, 
        kFailed = 1 << 6, 
        kStageWait = 1 << 7, 
        kRunOnce = 1 << 8,
        kExcludeFromExport = 1 << 9, 
        kWarnOnAliasFillFailure = 1 << 10, 
        kActive = 1 << 11,
        kRepeatsConditions = 1 << 12, 
        kKeepInstance = 1 << 13, 
        kWantDormant = 1 << 14,
        kHasDialogueData = 1 << 15
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct QUEST_STAGE_DATA
    {
        public enum Flag : byte
        {
            kNone = 0,
            kStartUpStage = 1 << 1,
            kShutDownStage = 1 << 2,
            kKeepInstanceDataFromHereOn = 1 << 3
        }

        internal ushort Index;
        internal byte Flags;
        internal byte pad3;
        internal uint pad4;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TESQuestStage
    {
        internal QUEST_STAGE_DATA Data;
    }

    public enum QUEST_OBJECTIVE_STATE : byte
    {
        kDormant = 0,
        kDisplayed = 1,
        kCompleted = 2,
        kCompletedDisplayed = 3,
        kFailed = 4,
        kFailedDisplayed = 5
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ParentSpaceNode
    {
        internal bool IsWorldspace;
        internal byte pad01;
        internal byte pad02;
        internal byte pad03;
        internal byte pad04;
        internal byte pad05;
        internal byte pad06;
        internal byte pad07;
        internal TESWorldSpace.Internal* Worldspace;
        internal TESObjectCELL.Internal* InteriorCell;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TeleportLink
    {
        internal TESObjectREFR.Internal* Ref;
        internal NiPoint3 TeleportLocation;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TeleportPath
    {
        internal BSTArray<ParentSpaceNode>.Internal Spaces;
        internal BSTArray<TeleportLink>.Internal TeleportRefs;
        internal NiPoint3 Start;
        internal NiPoint3 End;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TESQuestTarget
    {
        internal byte Flags;
        internal byte pad01;
        internal byte pad02;
        internal byte pad03;
        internal byte pad04;
        internal byte pad05;
        internal byte pad06;
        internal byte pad07;
        internal TESCondition Conditions;
        internal uint Alias;
        internal uint pad14;
        internal TeleportPath TeleportPath;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BGSQuestObjective
    {
        internal BSFixedString DisplayText;
        internal TESQuest.Internal* OwnerQuest;
        internal TESQuestTarget** Targets;
        internal uint NumTargets;
        internal ushort Index;
        internal bool Initialized;
        internal QUEST_OBJECTIVE_STATE State;
        internal uint Flags;
        internal uint pad24;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BGSStoryEvent
    {
        internal uint Id;
        internal uint Index;
        internal ulong Member0;
        internal ulong Member1;
        internal ulong Member2;
        internal ulong Member3;
        internal ulong Member4;
        internal ulong Member5;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BGSQuestInstanceText
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct StringData
        {
            internal uint AliasID;
            internal uint FullNameFormID;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GlobalValueData
        {
            internal TESGlobal.Internal* Global;
            internal float Value;
            internal uint pad0C;
        }

        internal uint ID;
        internal uint pad04;
        internal BSTArray<StringData>.Internal StringDataArray;
        internal BSTArray<GlobalValueData>.Internal ValueDataArray;
        internal ushort JournalStage;
        internal sbyte JournalStageItem;
        internal byte pad3B;
        internal uint pad3C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BGSScenePhase
    {
        internal TESCondition StartConditions;
        internal TESCondition CompletionConditions;
        internal BGSStoryManagerQuestNode.Internal* QuestNode;
    }

    public unsafe readonly struct TESWorldSpace(TESWorldSpace.Internal* ptr)
        : ITESWorldSpace, IFromNative<TESWorldSpace, TESWorldSpace.Internal>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal TESForm.Internal Base_0;
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator TESWorldSpace(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESWorldSpace instance) => (Internal*)instance.Native.ToPointer();

        public static TESWorldSpace FromNative(nint ptr) => new((Internal*)ptr);
    }

    public unsafe interface ITESWorldSpace : ITESForm;

    public unsafe readonly struct TESObjectCELL(TESObjectCELL.Internal* ptr)
        : ITESObjectCELL, IFromNative<TESObjectCELL, TESObjectCELL.Internal>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal TESForm.Internal Base_0;
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator TESObjectCELL(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESObjectCELL instance) => (Internal*)instance.Native.ToPointer();

        public static TESObjectCELL FromNative(nint ptr) => new((Internal*)ptr);
    }

    public unsafe interface ITESObjectCELL : ITESForm;

    public unsafe readonly struct BGSStoryManagerBranchNode(BGSStoryManagerBranchNode.Internal* ptr)
        : IBGSStoryManagerBranchNode, IFromNative<BGSStoryManagerBranchNode, BGSStoryManagerBranchNode.Internal>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal BGSStoryManagerNodeBase.Internal Base_0;
        }

        static BGSStoryManagerBranchNode()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_BGSStoryManagerBranchNode", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_BGSStoryManagerBranchNode", 0));
            _vtables.Add("BGSStoryManagerTreeForm", VTABLES.Get("VTABLE_BGSStoryManagerBranchNode", 0));
            _vtables.Add("BGSStoryManagerNodeBase", VTABLES.Get("VTABLE_BGSStoryManagerBranchNode", 0));
            _vtables.Add("BGSStoryManagerBranchNode", VTABLES.Get("VTABLE_BGSStoryManagerBranchNode", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator BGSStoryManagerBranchNode(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BGSStoryManagerBranchNode instance) => (Internal*)instance.Native.ToPointer();

        public static BGSStoryManagerBranchNode FromNative(nint ptr) => new((Internal*)ptr);
    }

    public unsafe interface IBGSStoryManagerBranchNode : IBGSStoryManagerNodeBase;

    public unsafe readonly struct QueuedPromoteQuestTask(QueuedPromoteQuestTask.Internal* ptr)
        : IQueuedPromoteQuestTask, IFromNative<QueuedPromoteQuestTask, QueuedPromoteQuestTask.Internal>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal nint unk00;
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator QueuedPromoteQuestTask(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(QueuedPromoteQuestTask instance) => (Internal*)instance.Native.ToPointer();

        public static QueuedPromoteQuestTask FromNative(nint ptr) => new((Internal*)ptr);
    }

    public unsafe interface IQueuedPromoteQuestTask : IFromNative, IHaveVtable;
}
