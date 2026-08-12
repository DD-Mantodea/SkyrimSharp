using SkyrimSharpLoader.Compat.OStim.Interop.GameAPI;
using String = SkyrimSharpLoader.Interop.Standard.String;

namespace SkyrimSharpLoader.Compat.OStim.Interop.Sound
{
    public unsafe struct VoiceSet
    {
        public String Name;

        public GameVoice Voice;

        public ReactionSet Moan;

        public ReactionSet Climax;

        public ReactionSet ClimaxCommentSelf;

        public ReactionSet ClimaxCommentOther;

        public fixed byte EventActorReactions[64]; //unordered_map<string, ReactionSet>

        public fixed byte EventTargetReactions[64]; //unordered_map<string, ReactionSet>

        public fixed byte EventPerformerReactions[64]; //unordered_map<string, ReactionSet>

        public GameDialogue PostSceneDialogue;
    }
}
