namespace SkyrimSharpLoader.Compat.OStim.OSceneSelector
{
    public class OSceneConfig
    {
        public string ID;

        public bool NoFurniture = false;

        public ActorType ActorType;

        public List<string> AllTags = [];

        public List<string> FromModPack = [];

        public List<string> BlacklistID = [];

        public List<string> AnyMaleHasAnyTags = [];

        public List<string> AnyFemaleHasAnyTags = [];

        public List<string> AnyMaleHasAllTags = [];

        public List<string> AnyFemaleHasAllTags = [];

        public List<string> AllMaleHasAnyTags = [];

        public List<string> AllFemaleHasAnyTags = [];

        public List<string> AllMaleHasAllTags = [];

        public List<string> AllFemaleHasAllTags = [];

        public List<string> NoMaleHasAnyTags = [];

        public List<string> NoFemaleHasAnyTags = [];

        public List<string> AnyMSoloActions = [];

        public List<string> AllMSoloActions = [];

        public List<string> NoMSoloActions = [];

        public List<string> AnyFSoloActions = [];

        public List<string> AllFSoloActions = [];

        public List<string> NoFSoloActions = [];

        public List<string> AnyFMActions = [];

        public List<string> AllFMActions = [];

        public List<string> NoFMActions = [];

        public List<string> AnyMFActions = [];

        public List<string> AllMFActions = [];

        public List<string> NoMFActions = [];

        public List<OSelectorAction> OnlyActions = [];
    }

    public enum ActorType
    {
        M,
        F,
        MF,
        MM,
        FF,
        MFF,
        MMF,
        MFFF,
        MMMF,
        MFFFF,
        MMMMF
    }
}
