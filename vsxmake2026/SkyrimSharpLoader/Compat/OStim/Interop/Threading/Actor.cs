using SkyrimSharpLoader.Compat.OStim.Interop.GameAPI;
using SkyrimSharpLoader.Compat.OStim.Interop.Graph;
using SkyrimSharpLoader.Compat.OStim.Interop.Sound;
using Thread = SkyrimSharpLoader.Compat.OStim.OThread.Thread;

namespace SkyrimSharpLoader.Compat.OStim.Interop.Threading
{
    public unsafe struct Actor
    {
        internal void** Vtable;

        internal int Index;

        internal fixed byte Metadata[0x98]; //Metadata

        internal Thread* Thread;

        internal GameActor GameActor;

        internal float ScaleBefore;

        internal GamePosition PositionBefore;

        internal bool IsPlayer;

        internal bool Female;

        internal bool Schlong;

        internal GraphActor* GraphActor;

        internal GameActor PrimaryPartner;

        internal int Speed;

        internal float ScaleMult;

        internal int SosBend;

        internal int SosOffset;

        internal bool Undressed;

        internal GameSlotMask UndressedMask;

        internal fixed byte UndressedItems[24]; //vector<GameArmor>

        internal bool WeaponsRemoved;

        internal GameWeaponry Weaponry;

        internal float RmHeight;

        internal float HeelOffset;

        internal bool HeelOffsetRemoved;

        internal fixed byte StatFactions[16]; //set<GameFaction>

        private bool _stallClimax;

        private bool _awaitingOrgasm;

        private bool _awaitingClimax;

        private bool _awaitingClimaxInner;

        private int _timesClimaxed;

        private float _timeUntilClimax;

        private fixed byte _equipObjects[64]; //unordered_map<string, EquipObjectHandler>

        private fixed byte _phonemeObjects[24]; //vector<string>

        private fixed byte _climaxListeners[24]; //vector<function<void()>>

        private float _excitement;

        private float _baseExcitementInc;

        private float _excitementMultiplier;

        private float _loopExcitementInc;

        private float _maxExcitement;

        private float _loopExcitementDecay;

        private int _excitementDecayCooldown;

        private void* _nodeExpressions; // vector<FacialExpression*>*

        private void* _underlyingExpression; //GenderExpression*

        private int _underlyingExpressionCooldown;

        private fixed byte _eyeballModifierOverride[64]; //unordered_map<int, FaceModifier>

        private void* _eventExpression; //GenderExpression*

        private int _eventExpressionCooldown;

        private void* _overrideExpressions; // vector<FacialExpression*>*

        private void* _overrideExpression; //GenderExpression*

        private int _overrideExpressionCooldown;

        private void* _actorExpressions; // vector<FacialExpression*>*

        private fixed byte _modifierUpdaters[64]; //unordered_map<int, ExpressionUpdater>

        private fixed byte _phonemeUpdaters[64]; //unordered_map<int, ExpressionUpdater>

        private VoiceSet VoiceSet;

        private bool _actorMuted;

        private bool _actorMuffled;

        private bool _muted;

        private bool _muffled;

        private int _soundGracePeriod;

        private int _moanCooldown;

        private void* _lastMoan; //GameSound*

        private int _eventTimer;

        private void* _eventReaction; //ReactionSet*

        private GameActor _eventPartner;

        private int _dialogueCountdown;

        private bool _isTalking;
    }
}
