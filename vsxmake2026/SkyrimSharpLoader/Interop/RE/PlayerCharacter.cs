using SkyrimSharpLoader.Internal;
using SkyrimSharpLoader.Interop.Interfaces;

namespace SkyrimSharpLoader.Interop.RE
{
    //TODO
    public unsafe readonly struct PlayerCharacter(PlayerCharacter.Internal* ptr) : IPlayerCharacter, IFromNative<PlayerCharacter, PlayerCharacter.Internal>
    {
        public enum EventType
        {
            kThief = 3,
            kContainer = 5,
            kDeadBody = 6
        }

        public enum GrabbingType
        {
            kNone = 0,
            kNormal,
            kTelekinesis
        }

        [Flags]
        public enum ByCharGenFlag : byte
        {
            kNone = 0,
            kDisableSaving = 1 << 0,
            kDisableWaiting = 1 << 1,
            kShowControlsDisabledMessage = 1 << 2
        }

        public struct GrabData
        {
            internal BSTSmallArray<hkRefPtr<bhkMouseSpringAction.Internal>>.Internal GrabSpring;

            internal ObjectRefHandle GrabbedObject;

            internal float GrabObjectWeight;

            internal float GrabDistance;

            internal float unk004;

            internal ulong unk008;
        }

        public struct Internal
        {
            internal Character.Internal Base_0;

            internal BSTEventSource<BGSActorCellEvent>.Internal Base_1;

            internal BSTEventSource<BGSActorDeathEvent>.Internal Base_2;

            internal BSTEventSource<PositionPlayerEvent>.Internal Base_3;

            internal BSTEventSink<MenuOpenCloseEvent>.Internal Base_4;

            internal BSTEventSink<MenuModeChangeEvent>.Internal Base_5;

            internal BSTEventSink<UserEventEnabledEvent>.Internal Base_6;

            internal BSTEventSink<TESTrackedStatsEvent>.Internal Base_7;

            internal bool Activate(TESObjectREFR.Internal* a_targetRef, TESObjectREFR.Internal* a_activatorRef, byte a_arg3, TESBoundObject.Internal* a_object, int a_targetCount)
                => Base_0.Activate(a_targetRef, a_activatorRef, a_arg3, a_object, a_targetCount);
        }

        public nint Native { get; } = new(ptr);

        public static implicit operator PlayerCharacter(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(PlayerCharacter instance) => (Internal*)instance.Native.ToPointer();

        public static implicit operator TESObjectREFR(PlayerCharacter instance) => TESObjectREFR.FromNative(instance.Native);

        public static PlayerCharacter FromNative(nint ptr) => new((Internal*)ptr);

        private static Internal* _singletonPtr;

        public static PlayerCharacter Singleton
        {
            get
            {
                if (_singletonPtr == null)
                {
                    var niPtr = (NiPointer<Internal>*)AddressLib.GetAddr(403521);

                    _singletonPtr = niPtr->Get();
                }

                return new(_singletonPtr);
            }
        }

        public bool Activate(TESObjectREFR targetRef, TESObjectREFR activatorRef, byte arg3, TESBoundObject obj, int targetCount)
            => ((Internal*)Native.ToPointer())->Activate(targetRef, activatorRef, arg3, obj, targetCount);
    }

    public interface IPlayerCharacter :
        ICharacter,
        IBSTEventSource<BGSActorCellEvent>,
        IBSTEventSource<BGSActorDeathEvent>,
        IBSTEventSource<PositionPlayerEvent>,
        IBSTEventSink<MenuOpenCloseEvent>,
        IBSTEventSink<MenuModeChangeEvent>,
        IBSTEventSink<UserEventEnabledEvent>,
        IBSTEventSink<TESTrackedStatsEvent>;

    public struct BGSActorDeathEvent;

    public struct UserEventEnabledEvent;
}
