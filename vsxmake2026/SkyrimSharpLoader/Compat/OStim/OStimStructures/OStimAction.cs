using Newtonsoft.Json.Linq;

namespace SkyrimSharpLoader.Compat.OStim.OStimStructures
{
    public class OStimAction
    {
        public string ID;

        public List<string> Aliases;

        public ActActor Actor;

        public ActActor Target;

        public ActActor Performer;

        public List<string> Tags;

        public class ActActor
        {
            public string Info;

            public float Stimulation;

            public float MaxStimulation;

            public bool FullStrip;

            public bool Moan;

            public bool Muffled;

            public string ExpressionOverride;

            public List<string> Requirements;

            public List<int> StrippingSlots;

            public JToken Faction;

            public Dictionary<string, List<string>> StringLists;

            public Dictionary<string, float> Floats;
        }

        public class Faction
        {
            public string Info;

            public string Mod;

            public string FormID;
        }
    }
}
