using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct Actor(Actor.Internal* ptr) : IActor, IFromNative<Actor, Actor.Internal>
    {
        public enum SlotTypes
        {
            kLeftHand = 0,
            kRightHand,
            kUnknown,
            kPowerOrShout,

            kTotal
        }

        [Flags]
        public enum BOOL_BITS : uint
        {
            kNone = 0,
            kDelayUpdateScenegraph = 1 << 0,
            kProcessMe = 1 << 1,
            kMurderAlarm = 1 << 2,
            kHasSceneExtra = 1 << 3,
            kHeadingFixed = 1 << 4,
            kSpeakingDone = 1 << 5,
            kIgnoreChangeAnimationCall = 1 << 6,
            kSoundFileDone = 1 << 7,
            kVoiceFileDone = 1 << 8,
            kInTempChangeList = 1 << 9,
            kDoNotRunSayToCallback = 1 << 10,
            kDead = 1 << 11,
            kForceGreetingPlayer = 1 << 12,
            kForceUpdateQuestTarget = 1 << 13,
            kSearchingInCombat = 1 << 14,
            kAttackOnNextTheft = 1 << 15,
            kEvpBuffered = 1 << 16,
            kResetAI = 1 << 17,
            kInWater = 1 << 18,
            kSwimming = 1 << 19,
            kVoicePausedByScript = 1 << 20,
            kWasInFrustrum = 1 << 21,
            kShouldRotateToTrack = 1 << 22,
            kSetOnDeath = 1 << 23,
            kDoNotPadVoice = 1 << 24,
            kFootIKInRange = 1 << 25,
            kPlayerTeammate = 1 << 26,
            kGivePlayerXP = 1 << 27,
            kSoundCallbackSuccess = 1 << 28,
            kUseEmotion = 1 << 29,
            kGuard = 1 << 30,
            kParalyzed = 1u << 31
        }

        [Flags]
        public enum BOOL_FLAGS : uint
        {
            kNone = 0,
            kScenePackage = 1 << 0,
            kIsAMount = 1 << 1,
            kMountPointClear = 1 << 2,
            kGettingOnOffMount = 1 << 3,
            kInRandomScene = 1 << 4,
            kNoBleedoutRecovery = 1 << 5,
            kInBleedoutAnimation = 1 << 6,
            kCanDoFavor = 1 << 7,
            kShouldAnimGraphUpdate = 1 << 8,
            kCanSpeakToEssentialDown = 1 << 9,
            kBribedByPlayer = 1 << 10,
            kAngryWithPlayer = 1 << 11,
            kIsTrespassing = 1 << 12,
            kCanSpeak = 1 << 13,
            kIsInKillMove = 1 << 14,
            kAttackOnSight = 1 << 15,
            kIsCommandedActor = 1 << 16,
            kForceOneAnimgraphUpdate = 1 << 17,
            kEssential = 1 << 18,
            kProtected = 1 << 19,
            kAttackingDisabled = 1 << 20,
            kCastingDisabled = 1 << 21,
            kSceneHeadTrackRotation = 1 << 22,
            kForceIncMinBoneUpdate = 1 << 23,
            kCrimeSearch = 1 << 24,
            kMovingIntoLoadedArea = 1 << 25,
            kDoNotShowOnStealthMeter = 1 << 26,
            kMovementBlocked = 1 << 27,
            kAllowInstantFurniturePopInPlayerCell = 1 << 28,
            kForceAnimGraphUpdate = 1 << 29,
            kCheckAddEffectDualCast = 1 << 30,
            kUnderwater = 1u << 31
        }

        [Flags]
        public enum ChangeFlags : uint
        {
            kLifeState = 1 << 10,
            kPackageExtraData = 1 << 11,
            kMerchantContainer = 1 << 12,
            kDismemberedLimbs = 1 << 17,
            kLeveledActor = 1 << 18,
            kDispModifiers = 1 << 19,
            kTempModifiers = 1 << 20,
            kDamageModifiers = 1 << 21,
            kOverrideModifiers = 1 << 22,
            kPermanentModifiers = 1 << 23
        }

        [Flags]
        public enum RecordFlags : uint
        {
            kDeleted = 1 << 5,
            kStartsDead = 1 << 9,
            kPersistent = 1 << 10,
            kInitiallyDisabled = 1 << 11,
            kIgnored = 1 << 12,
            kNoAIAcquire = 1 << 25,
            kDontHavokSettle = 1 << 29
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ACTOR_RUNTIME_DATA
        {
            internal BOOL_BITS BoolBits;
            internal float UpdateTargetTimer;
            internal ACTOR_CRITICAL_STAGE CriticalStage;
            internal uint pad0EC;
            internal void* CurrentProcess;
            internal ObjectRefHandle DialogueItemTarget;
            internal BSPointerHandle<Internal> CurrentCombatTarget;
            internal BSPointerHandle<Internal> MyKiller;
            internal float CheckMyDeadBodyTimer;
            internal float VoiceTimer;
            internal float UnderWaterTimer;
            internal int ThiefCrimeStamp;
            internal int ActionValue;
            internal float TimerOnAction;
            internal uint unk11C;
            internal NiPoint3 EditorLocCoord;
            internal float EditorLocRot;
            internal void* EditorLocForm;
            internal BGSLocation.Internal* EditorLocation;
            internal void* ActorMover;
            internal void* MovementController;
            internal void* unk150;
            internal void* CombatController;
            internal void* VendorFaction;
            internal AITimeStamp CalculateVendorFactionTimer;
            internal uint EmotionType;
            internal uint EmotionValue;
            internal uint unk174;
            internal uint unk178;
            internal uint IntimidateBribeDayStamp;
            internal ulong unk180;
            internal fixed byte AddedSpells[0x18];
            internal fixed ulong MagicCasters[(int)SlotTypes.kTotal];
            internal fixed ulong SelectedSpells[(int)SlotTypes.kTotal];
            internal void* SelectedPower;
            internal uint unk1E8;
            internal uint pad1EC;
            internal void* Race;
            internal float EquippedWeight;
            internal BOOL_FLAGS BoolFlags;
            internal ActorValueStorage AvStorage;
            internal BGSDialogueBranch.Internal* ExclusiveBranch;
            internal Modifiers HealthModifiers;
            internal Modifiers MagickaModifiers;
            internal Modifiers StaminaModifiers;
            internal Modifiers VoicePointsModifiers;
            internal float LastUpdate;
            internal uint LastSeenTime;
            internal void* Biped;
            internal float ArmorRating;
            internal float ArmorBaseFactorSum;
            internal sbyte SoundCallBackSet;
            internal byte unk271;
            internal byte unk272;
            internal byte unk273;
            internal uint unk274;
            internal ulong unk278;
            internal ulong unk280;
            internal CRITICAL_SECTION unk288;
        }

        public static FormType FormType = FormType.ActorCharacter;

        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal TESObjectREFR.Internal Base_0;
            internal MagicTarget.Internal Base_1;
            internal ActorValueOwner.Internal Base_2;
            internal ActorState.Internal Base_3;
            internal BSTEventSink<BSTransformDeltaEvent>.Internal Base_4;
            internal BSTEventSink<bhkCharacterMoveFinishEvent>.Internal Base_5;
            internal IPostAnimationChannelUpdateFunctor Base_6;

            internal ACTOR_RUNTIME_DATA RuntimeData;
        }

        static Actor()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_Actor", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_Actor", 0));
            _vtables.Add("TESObjectREFR", VTABLES.Get("VTABLE_Actor", 0));
            _vtables.Add("Actor", VTABLES.Get("VTABLE_Actor", 0));

            _vtables.Add("BSHandleRefObject", VTABLES.Get("VTABLE_Actor", 1));

            _vtables.Add("BSTEventSink<BSAnimationGraphEvent>", VTABLES.Get("VTABLE_Actor", 2));

            _vtables.Add("IAnimationGraphManagerHolder", VTABLES.Get("VTABLE_Actor", 3));

            _vtables.Add("MagicTarget", VTABLES.Get("VTABLE_Actor", 4));

            _vtables.Add("ActorValueOwner", VTABLES.Get("VTABLE_Actor", 5));

            _vtables.Add("ActorState", VTABLES.Get("VTABLE_Actor", 6));

            _vtables.Add("BSTEventSink<BSTransformDeltaEvent>", VTABLES.Get("VTABLE_Actor", 7));

            _vtables.Add("BSTEventSink<bhkCharacterMoveFinishEvent>", VTABLES.Get("VTABLE_Actor", 8));

            _vtables.Add("IPostAnimationChannelUpdateFunctor", VTABLES.Get("VTABLE_Actor", 9));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator Actor(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(Actor instance) => (Internal*)instance.Native.ToPointer();

        public static implicit operator TESObjectREFR(Actor instance) => TESObjectREFR.FromNative(instance.Native);

        public static Actor FromNative(nint ptr) => new((Internal*)ptr);

        public ACTOR_RUNTIME_DATA* RuntimeData => &((Internal*)Native.ToPointer())->RuntimeData;

        public BOOL_BITS BoolBits
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.BoolBits;
            set => ((Internal*)Native.ToPointer())->RuntimeData.BoolBits = value;
        }

        public BOOL_FLAGS BoolFlags
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.BoolFlags;
            set => ((Internal*)Native.ToPointer())->RuntimeData.BoolFlags = value;
        }

        public ACTOR_CRITICAL_STAGE CriticalStage
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.CriticalStage;
            set => ((Internal*)Native.ToPointer())->RuntimeData.CriticalStage = value;
        }

        public float UpdateTargetTimer
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.UpdateTargetTimer;
            set => ((Internal*)Native.ToPointer())->RuntimeData.UpdateTargetTimer = value;
        }

        public void* CurrentProcess
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.CurrentProcess;
            set => ((Internal*)Native.ToPointer())->RuntimeData.CurrentProcess = value;
        }

        public ObjectRefHandle DialogueItemTarget
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.DialogueItemTarget;
            set => ((Internal*)Native.ToPointer())->RuntimeData.DialogueItemTarget = value;
        }

        public BSPointerHandle<Internal> CurrentCombatTarget
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.CurrentCombatTarget;
            set => ((Internal*)Native.ToPointer())->RuntimeData.CurrentCombatTarget = value;
        }

        public BSPointerHandle<Internal> MyKiller
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.MyKiller;
            set => ((Internal*)Native.ToPointer())->RuntimeData.MyKiller = value;
        }

        public float CheckMyDeadBodyTimer
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.CheckMyDeadBodyTimer;
            set => ((Internal*)Native.ToPointer())->RuntimeData.CheckMyDeadBodyTimer = value;
        }

        public float VoiceTimer
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.VoiceTimer;
            set => ((Internal*)Native.ToPointer())->RuntimeData.VoiceTimer = value;
        }

        public float UnderWaterTimer
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.UnderWaterTimer;
            set => ((Internal*)Native.ToPointer())->RuntimeData.UnderWaterTimer = value;
        }

        public int ThiefCrimeStamp
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.ThiefCrimeStamp;
            set => ((Internal*)Native.ToPointer())->RuntimeData.ThiefCrimeStamp = value;
        }

        public int ActionValue
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.ActionValue;
            set => ((Internal*)Native.ToPointer())->RuntimeData.ActionValue = value;
        }

        public float TimerOnAction
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.TimerOnAction;
            set => ((Internal*)Native.ToPointer())->RuntimeData.TimerOnAction = value;
        }

        public NiPoint3 EditorLocCoord
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.EditorLocCoord;
            set => ((Internal*)Native.ToPointer())->RuntimeData.EditorLocCoord = value;
        }

        public float EditorLocRot
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.EditorLocRot;
            set => ((Internal*)Native.ToPointer())->RuntimeData.EditorLocRot = value;
        }

        public TESForm* EditorLocForm
        {
            get => (TESForm*)((Internal*)Native.ToPointer())->RuntimeData.EditorLocForm;
            set => ((Internal*)Native.ToPointer())->RuntimeData.EditorLocForm = value;
        }

        public BGSLocation.Internal* EditorLocation
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.EditorLocation;
            set => ((Internal*)Native.ToPointer())->RuntimeData.EditorLocation = value;
        }

        public void* ActorMover
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.ActorMover;
            set => ((Internal*)Native.ToPointer())->RuntimeData.ActorMover = value;
        }

        public void* MovementController
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.MovementController;
            set => ((Internal*)Native.ToPointer())->RuntimeData.MovementController = value;
        }

        public void* CombatController
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.CombatController;
            set => ((Internal*)Native.ToPointer())->RuntimeData.CombatController = value;
        }

        public void* VendorFaction
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.VendorFaction;
            set => ((Internal*)Native.ToPointer())->RuntimeData.VendorFaction = value;
        }

        public AITimeStamp CalculateVendorFactionTimer
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.CalculateVendorFactionTimer;
            set => ((Internal*)Native.ToPointer())->RuntimeData.CalculateVendorFactionTimer = value;
        }

        public EmotionType EmotionType
        {
            get => (EmotionType)((Internal*)Native.ToPointer())->RuntimeData.EmotionType;
            set => ((Internal*)Native.ToPointer())->RuntimeData.EmotionType = (uint)value;
        }

        public uint EmotionValue
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.EmotionValue;
            set => ((Internal*)Native.ToPointer())->RuntimeData.EmotionValue = value;
        }

        public uint IntimidateBribeDayStamp
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.IntimidateBribeDayStamp;
            set => ((Internal*)Native.ToPointer())->RuntimeData.IntimidateBribeDayStamp = value;
        }

        public void* Race
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.Race;
            set => ((Internal*)Native.ToPointer())->RuntimeData.Race = value;
        }

        public float EquippedWeight
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.EquippedWeight;
            set => ((Internal*)Native.ToPointer())->RuntimeData.EquippedWeight = value;
        }

        public ActorValueStorage AvStorage => ((Internal*)Native.ToPointer())->RuntimeData.AvStorage;

        public BGSDialogueBranch.Internal* ExclusiveBranch
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.ExclusiveBranch;
            set => ((Internal*)Native.ToPointer())->RuntimeData.ExclusiveBranch = value;
        }

        public Modifiers HealthModifiers => ((Internal*)Native.ToPointer())->RuntimeData.HealthModifiers;

        public Modifiers MagickaModifiers => ((Internal*)Native.ToPointer())->RuntimeData.MagickaModifiers;

        public Modifiers StaminaModifiers => ((Internal*)Native.ToPointer())->RuntimeData.StaminaModifiers;

        public Modifiers VoicePointsModifiers => ((Internal*)Native.ToPointer())->RuntimeData.VoicePointsModifiers;

        public float LastUpdate
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.LastUpdate;
            set => ((Internal*)Native.ToPointer())->RuntimeData.LastUpdate = value;
        }

        public uint LastSeenTime
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.LastSeenTime;
            set => ((Internal*)Native.ToPointer())->RuntimeData.LastSeenTime = value;
        }

        public void* Biped
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.Biped;
            set => ((Internal*)Native.ToPointer())->RuntimeData.Biped = value;
        }

        public float ArmorRating
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.ArmorRating;
            set => ((Internal*)Native.ToPointer())->RuntimeData.ArmorRating = value;
        }

        public float ArmorBaseFactorSum
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.ArmorBaseFactorSum;
            set => ((Internal*)Native.ToPointer())->RuntimeData.ArmorBaseFactorSum = value;
        }

        public sbyte SoundCallBackSet
        {
            get => ((Internal*)Native.ToPointer())->RuntimeData.SoundCallBackSet;
            set => ((Internal*)Native.ToPointer())->RuntimeData.SoundCallBackSet = value;
        }
    }

    public interface IActor :
        ITESObjectREFR,
        IMagicTarget,
        IActorValueOwner,
        IActorState,
        IBSTEventSink<BSTransformDeltaEvent>,
        IBSTEventSink<bhkCharacterMoveFinishEvent>,
        IIPostAnimationChannelUpdateFunctor
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Modifiers
    {
        internal fixed float modifiers[3];
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ActorValueStorage
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct LocalMap<T> where T : unmanaged
        {
            internal BSFixedString ActorValues;
            internal T* Entries;
        }

        internal LocalMap<float> BaseValues;
        internal LocalMap<Modifiers> Modifiers;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AITimeStamp
    {
        internal float TimeStamp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CRITICAL_SECTION
    {
        internal void* DebugInfo;
        internal int LockCount;
        internal int RecursionCount;
        internal void* OwningThread;
        internal void* LockSemaphore;
        internal ulong SpinCount;
    }

    public enum ACTOR_CRITICAL_STAGE
    {
        kNone = 0,
        kGooStart = 1,
        kGooEnd = 2,
        kDisintegrateStart = 3,
        kDisintegrateEnd = 4,

        kTotal
    }

    public enum ACTOR_LIFE_STATE : uint
    {
        kAlive = 0,
        kDying = 1,
        kDead = 2,
        kUnconcious = 3,
        kReanimate = 4,
        kRecycle = 5,
        kRestrained = 6,
        kEssentialDown = 7,
        kBleedout = 8
    }

    public enum ATTACK_STATE_ENUM : uint
    {
        kNone = 0,
        kDraw = 1,
        kSwing = 2,
        kHit = 3,
        kNextAttack = 4,
        kFollowThrough = 5,
        kBash = 6,
        kBowDraw = 8,
        kBowAttached = 9,
        kBowDrawn = 10,
        kBowReleasing = 11,
        kBowReleased = 12,
        kBowNextAttack = 13,
        kBowFollowThrough = 14,
        kFire = 15,
        kFiring = 16,
        kFired = 17
    }

    public enum FLY_STATE : uint
    {
        kNone = 0,
        kTakeOff = 1,
        kCruising = 2,
        kHovering = 3,
        kLanding = 4,
        kPerching = 5,
        kAction = 6
    }

    public enum KNOCK_STATE_ENUM : uint
    {
        kNormal = 0,
        kExplode = 1,
        kExplodeLeadIn = 2,
        kOut = 3,
        kOutLeadIn = 4,
        kQueued = 5,
        kGetUp = 6,
        kDown = 7,
        kWaitForTaskQueue = 8
    }

    public enum SIT_SLEEP_STATE : uint
    {
        kNormal = 0,
        kWantToSit = 1,
        kWaitingForSitAnim = 2,

        kIsSitting = 3,
        kRidingMount = kIsSitting,

        kWantToStand = 4,

        kWantToSleep = 5,
        kWaitingForSleepAnim = 6,
        kIsSleeping = 7,
        kWantToWake = 8
    }

    public enum WEAPON_STATE : uint
    {
        kSheathed = 0,
        kWantToDraw = 1,
        kDrawing = 2,
        kDrawn = 3,
        kWantToSheathe = 4,
        kSheathing = 5
    }

    public enum SKILL_ACTION
    {
        kNormalUse = 0,
        kPowerAttack,
        kBash,
        kLockpickSuccess,
        kLockpickBroken
    }

    public enum EmotionType
    {
        kNeutral = 0,
        kAnger = 1,
        kDisgust = 2,
        kFear = 3,
        kSad = 4,
        kHappy = 5,
        kSurprise = 6,
        kPuzzled = 7
    }
}
