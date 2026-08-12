namespace SkyrimSharpLoader.Compat.OStim.OSceneSelector
{
    public class OSelectorAction
    {
        public string Type;

        public OSelectorGender Actor;

        public OSelectorGender Target;

        public override string ToString() => $"Type: {Type}, ActActor: {Actor}, Target: {Target}";
    }

    public enum OSelectorGender
    {
        M,
        F,
        NULL
    }
}
