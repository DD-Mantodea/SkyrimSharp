using SkyrimSharpLoader.Compat.OStim.Interop.GameAPI;
using String = SkyrimSharpLoader.Interop.Standard.String;

namespace SkyrimSharpLoader.Compat.OStim.Interop.Trait
{
    public unsafe struct ActorCondition
    {
        public String Type;

        public GameSex Sex;

        public fixed byte Requirements[16]; //set<string>
    }
}
