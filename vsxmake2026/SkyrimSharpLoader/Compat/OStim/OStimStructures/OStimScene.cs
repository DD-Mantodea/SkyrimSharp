using SkyrimSharpLoader.Compat.OStim.OSceneSelector;
using SkyrimSharpLoader.Extensions;

namespace SkyrimSharpLoader.Compat.OStim.OStimStructures
{
    public class OStimScene
    {
        public string ID = "";

        public string Name = "";

        public string ModPack = "";

        public string Furniture = "";

        public float Length = 0f;

        public List<string> Tags = [];

        public List<Actor> Actors = [];

        public List<Action> Actions = [];

        public List<Actor> MaleActors() => [.. Actors.Where(a => a.IsMale())];

        public List<Actor> FemaleActors() => [.. Actors.Where(a => a.IsFemale())];

        public OSelectorGender GetGender(int index)
        {
            if (index == -1)
                return OSelectorGender.NULL;

            return Actors[index].IsMale() ? OSelectorGender.M : OSelectorGender.F;
        }

        public int MaleCount() => MaleActors().Count;

        public int FemaleCount() => FemaleActors().Count;

        public bool HasTag(string tag) => Tags.Any(t => t.Equals(tag, StringComparison.OrdinalIgnoreCase));

        public bool HasTags(List<string> tags) => tags.All(tag => Tags.Any(t => t.Equals(tag, StringComparison.OrdinalIgnoreCase)));

        public bool IsMaleCount(int count) => MaleCount() == count;

        public bool IsFemaleCount(int count) => FemaleCount() == count;

        public bool IsMale(int index) => !Actors.OutOfRange(index) && Actors[index].IsMale();

        public bool IsFemale(int index) => !Actors.OutOfRange(index) && Actors[index].IsFemale();

        public bool MaleActorAction(Action action) => IsMale(action.Actor);

        public bool FemaleActorAction(Action action) => IsFemale(action.Actor);

        public bool MaleTargetAction(Action action) => action.Target != -1 && IsMale(action.Target);

        public bool FemaleTargetAction(Action action) => action.Target != -1 && IsFemale(action.Target);

        public bool HasMSoloAction(string action) => Actions.Any(a => MaleActorAction(a) && (a.Target == a.Actor || a.Target == -1) && a.IsAction(action));

        public bool HasAnyMSoloActions(List<string> actions) => actions.Any(HasMSoloAction);

        public bool HasAllMSoloActions(List<string> actions) => actions.All(HasMSoloAction);

        public bool HasNoMSoloActions(List<string> actions) => actions.All(a => !HasMSoloAction(a));

        public bool HasFSoloAction(string action) => Actions.Any(a => FemaleActorAction(a) && (a.Target == a.Actor || a.Target == -1) && a.IsAction(action));

        public bool HasAnyFSoloActions(List<string> actions) => actions.Any(HasFSoloAction);

        public bool HasAllFSoloActions(List<string> actions) => actions.All(HasFSoloAction);

        public bool HasNoFSoloActions(List<string> actions) => actions.All(a => !HasFSoloAction(a));

        public bool HasFMAction(string action) => Actions.Any(a => FemaleActorAction(a) && MaleTargetAction(a) && a.IsAction(action));

        public bool HasAnyFMActions(List<string> actions) => actions.Any(HasFMAction);

        public bool HasAllFMActions(List<string> actions) => actions.All(HasFMAction);

        public bool HasNoFMActions(List<string> actions) => actions.All(a => !HasFMAction(a));

        public bool HasMFAction(string action) => Actions.Any(a => MaleActorAction(a) && FemaleTargetAction(a) && a.IsAction(action));

        public bool HasAnyMFActions(List<string> actions) => actions.Any(HasMFAction);

        public bool HasAllMFActions(List<string> actions) => actions.All(HasMFAction);

        public bool HasNoMFActions(List<string> actions) => actions.All(a => !HasMFAction(a));

        public bool OnlyActions(List<OSelectorAction> actions) => actions.Count == Actions.Count &&
            actions.All(
                a => Actions.Any(
                    ac =>
                    GetGender(ac.Actor) == a.Actor &&
                    GetGender(ac.Target == -1 ? ac.Actor : ac.Target) == a.Target &&
                    ac.IsAction(a.Type)
                )
            );

        public class Actor
        {
            public string IntendedSex = "";

            public float Scale = 1f;

            public List<string> Tags = [];

            public bool FeetOnGround = false;

            public bool IsMale() => IntendedSex.ToLower().Equals("male");

            public bool IsFemale() => IntendedSex.ToLower().Equals("female");

            public bool HasTag(string tag) => Tags.Select(t => t.ToLower()).Contains(tag.ToLower());

            public bool HasAnyTags(List<string> tags) => tags.Any(t => Tags.Select(t => t.ToLower()).Contains(t.ToLower()));

            public bool HasAllTags(List<string> tags) => tags.All(t => Tags.Select(t => t.ToLower()).Contains(t.ToLower()));
        }

        public class Action
        {
            public string Type;

            public int Actor;

            public int Target = -1;

            public bool IsAction(string action) => action.ToLower().Equals(Type.ToLower());

            public bool HasTag(string tag) => OStim.Actions.FirstOrDefault(a => a.ID == Type)?.Tags.Any(t => t.Equals(tag, StringComparison.OrdinalIgnoreCase)) ?? false;
        }
    }
}
