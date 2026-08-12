namespace SkyrimSharpLoader.Compat.OStim.Interop.Sound
{
    public unsafe struct ReactionSet
    {
        internal fixed byte Sound[24]; //vector<SoundSet>

        internal fixed byte SoundMuffled[24]; //vector<SoundSet>

        internal fixed byte Dialogue[24]; //vector<DialogueSet>
    }
}
