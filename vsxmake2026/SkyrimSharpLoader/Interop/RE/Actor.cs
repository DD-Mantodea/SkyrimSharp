using SkyrimSharpLoader.Interop.Interfaces;
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
        public enum BOOL_BITS
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
            kParalyzed = 1 << 31
        };

        [Flags]
        public enum BOOL_FLAGS
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
            kUnderwater = 1 << 31
        };

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

        public struct ACTOR_RUNTIME_DATA
        {
            public BOOL_BITS BoolBits;

            public float UpdateTargetTimer;

            public ACTOR_CRITICAL_STAGE CriticalStage;

            public uint pad0EC;

            public void* CurrentProcess;

            public ObjectRefHandle DialogueItemTarget;

            public BSPointerHandle<Internal> CurrentCombatTarget;

            public BSPointerHandle<Internal> MyKiller;

            public float CheckMyDeadBodyTimer;

            public float VoiceTimer;

            public float UnderWaterTimer;

            public int ThiefCrimeStamp;

            public int ActionValue;

            public float TimerOnAction;

            public uint unk11C;

            public NiPoint3 EditorLocCoord;

            public float EditorLocRot;

            public TESForm* EditorLocForm;

            public BGSLocation.Internal* EditorLocation;
        }

        public static FormType FormType = FormType.ActorCharacter;

        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0xD0)]
        public struct Internal
        {
            internal TESObjectREFR.Internal Base_0;

            internal MagicTarget.Internal Base_1;

            internal ActorValueOwner.Internal Base_2;

            internal ActorState.Internal Base_3;

            internal BSTEventSink<BSTransformDeltaEvent>.Internal Base_4;

            internal BSTEventSink<bhkCharacterMoveFinishEvent>.Internal Base_5;

            internal IPostAnimationChannelUpdateFunctor Base_6;
        }

        static Actor()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_Actor", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_Actor", 0));
            _vtables.Add("TESObjectREFR", VTABLES.Get("VTABLE_Actor", 0));
            _vtables.Add("Actor", VTABLES.Get("VTABLE_Actor", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator Actor(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(Actor instance) => (Internal*)instance.Native.ToPointer();

        public static implicit operator TESObjectREFR(Actor instance) => TESObjectREFR.FromNative(instance.Native);

        public static Actor FromNative(nint ptr) => new((Internal*)ptr);
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

    public enum ACTOR_CRITICAL_STAGE
    {
        kNone = 0,
		kGooStart = 1,
		kGooEnd = 2,
		kDisintegrateStart = 3,
		kDisintegrateEnd = 4,

		kTotal
    };
}
