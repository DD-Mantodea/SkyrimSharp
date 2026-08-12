using SkyrimSharpLoader.Interop.RE;

namespace SkyrimSharpLoader.Compat.OStim.Interop.GameAPI
{
    public unsafe readonly struct GameWeaponry
    {
        internal readonly TESForm.Internal* RightHand;

        internal readonly TESForm.Internal* LeftHand;

        internal readonly void* Ammo; //TESAmmo*
    }
}
