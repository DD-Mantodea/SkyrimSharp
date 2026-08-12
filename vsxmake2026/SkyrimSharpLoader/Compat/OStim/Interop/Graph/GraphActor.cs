using SkyrimSharpLoader.Compat.OStim.Interop.GameAPI;
using SkyrimSharpLoader.Compat.OStim.Interop.Trait;
using String = SkyrimSharpLoader.Interop.Standard.String;

namespace SkyrimSharpLoader.Compat.OStim.Interop.Graph
{
    public unsafe struct GraphActor
    {
        public int SosBend;

        public float Scale;

        public float ScaleHeight;

        public bool FeetOnGround;

        public int ExpressionAction;

        public int AnimationIndex;

        public String UnderlyingExpression;

        public String ExpressionOverride;

        public bool NoStrip;

        public bool Moan;

        public bool Talk;

        public bool Muffled;

        public GamePosition Offset;

        public fixed byte EquipObjects[16]; //set<string>

        public fixed byte Factions[24]; //vector<GameFaction>

        public fixed byte StatFactions[24]; //vector<GameFaction>

        public fixed byte EyeballModifierOverride[64]; //unordered_map<int, FaceModifier>

        public fixed byte Tags[24]; //vector<GraphActorTag>

        public ActorCondition Condition;

        public fixed byte AutoTransitions[64]; //unordered_map<string, string>
    }
}
