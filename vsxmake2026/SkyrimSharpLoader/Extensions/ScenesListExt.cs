using SkyrimSharpLoader.Compat.OStim.OSceneSelector;
using SkyrimSharpLoader.Compat.OStim.OStimStructures;

namespace SkyrimSharpLoader.Extensions
{
    public static class ScenesListExt
    {
        public static Random Rand = new();

        public static List<OStimScene> FromModPack(this List<OStimScene> scenes, List<string> modPacks) => modPacks.Count == 0 ? scenes : [.. scenes.Where(s => modPacks.Contains(s.ModPack))];

        #region Gender

        public static List<OStimScene> M(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 1 && s.IsMaleCount(1) && s.IsFemaleCount(0))];

        public static List<OStimScene> F(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 1 && s.IsMaleCount(0) && s.IsFemaleCount(1))];

        public static List<OStimScene> MF(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 2 && s.IsMaleCount(1) && s.IsFemaleCount(1))];

        public static List<OStimScene> MM(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 2 && s.IsMaleCount(2) && s.IsFemaleCount(0))];

        public static List<OStimScene> FF(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 2 && s.IsMaleCount(0) && s.IsFemaleCount(2))];

        public static List<OStimScene> MFF(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 3 && s.IsMaleCount(1) && s.IsFemaleCount(2))];

        public static List<OStimScene> MMF(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 3 && s.IsMaleCount(2) && s.IsFemaleCount(1))];

        public static List<OStimScene> MFFF(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 4 && s.IsMaleCount(1) && s.IsFemaleCount(3))];

        public static List<OStimScene> MMMF(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 4 && s.IsMaleCount(3) && s.IsFemaleCount(1))];

        public static List<OStimScene> MFFFF(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 5 && s.IsMaleCount(1) && s.IsFemaleCount(4))];

        public static List<OStimScene> MMMMF(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Actors.Count == 5 && s.IsMaleCount(4) && s.IsFemaleCount(1))];
        #endregion

        #region Tags

        public static List<OStimScene> AllTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.HasTags(tags))];

        public static List<OStimScene> AnyMaleHasAnyTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.MaleActors().Any(a => a.HasAnyTags(tags)))];

        public static List<OStimScene> AnyFemaleHasAnyTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.FemaleActors().Any(a => a.HasAnyTags(tags)))];

        public static List<OStimScene> AnyMaleHasAllTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.MaleActors().Any(a => a.HasAllTags(tags)))];

        public static List<OStimScene> AnyFemaleHasAllTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.FemaleActors().Any(a => a.HasAllTags(tags)))];

        public static List<OStimScene> AllMaleHasAnyTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.MaleActors().All(a => a.HasAnyTags(tags)))];

        public static List<OStimScene> AllFemaleHasAnyTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.FemaleActors().All(a => a.HasAnyTags(tags)))];

        public static List<OStimScene> AllMaleHasAllTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.MaleActors().All(a => a.HasAllTags(tags)))];

        public static List<OStimScene> AllFemaleHasAllTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.FemaleActors().All(a => a.HasAllTags(tags)))];

        public static List<OStimScene> NoMaleHasAnyTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.MaleActors().All(a => !a.HasAnyTags(tags)))];

        public static List<OStimScene> NoFemaleHasAnyTags(this List<OStimScene> scenes, List<string> tags) => tags.Count == 0 ? scenes : [.. scenes.Where(s => s.FemaleActors().All(a => !a.HasAnyTags(tags)))];
        #endregion

        #region Actions

        public static List<OStimScene> AnyMSoloActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasAnyMSoloActions(actions))];

        public static List<OStimScene> AllMSoloActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasAllMSoloActions(actions))];

        public static List<OStimScene> NoMSoloActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasNoMSoloActions(actions))];

        public static List<OStimScene> AnyFSoloActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasAnyFSoloActions(actions))];

        public static List<OStimScene> AllFSoloActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasAllFSoloActions(actions))];

        public static List<OStimScene> NoFSoloActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasNoFSoloActions(actions))];

        public static List<OStimScene> AnyFMActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasAnyFMActions(actions))];

        public static List<OStimScene> AllFMActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasAllFMActions(actions))];

        public static List<OStimScene> NoFMActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasNoFMActions(actions))];

        public static List<OStimScene> AnyMFActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasAnyMFActions(actions))];

        public static List<OStimScene> AllMFActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasAllMFActions(actions))];

        public static List<OStimScene> NoMFActions(this List<OStimScene> scenes, List<string> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.HasNoMFActions(actions))];

        public static List<OStimScene> OnlyActions(this List<OStimScene> scenes, List<OSelectorAction> actions) => actions.Count == 0 ? scenes : [.. scenes.Where(s => s.OnlyActions(actions))];
        #endregion

        public static List<OStimScene> NoFurniture(this List<OStimScene> scenes) => [.. scenes.Where(s => s.Furniture == "")];

        public static string Random(this List<OStimScene> scenes)
        {
            if (scenes.Count == 0)
                return "";

            return scenes[Rand.Next(scenes.Count)].ID;
        }
    }
}
