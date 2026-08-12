namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct BIPED_MODEL
    {
        [Flags]
        public enum BipedObjectSlot
        {
            kNone = 0,
            kHead = 1 << 0,
            kHair = 1 << 1,
            kBody = 1 << 2,
            kHands = 1 << 3,
            kForearms = 1 << 4,
            kAmulet = 1 << 5,
            kRing = 1 << 6,
            kFeet = 1 << 7,
            kCalves = 1 << 8,
            kShield = 1 << 9,
            kTail = 1 << 10,
            kLongHair = 1 << 11,
            kCirclet = 1 << 12,
            kEars = 1 << 13,
            kModMouth = 1 << 14,
            kModNeck = 1 << 15,
            kModChestPrimary = 1 << 16,
            kModBack = 1 << 17,
            kModMisc1 = 1 << 18,
            kModPelvisPrimary = 1 << 19,
            kDecapitateHead = 1 << 20,
            kDecapitate = 1 << 21,
            kModPelvisSecondary = 1 << 22,
            kModLegRight = 1 << 23,
            kModLegLeft = 1 << 24,
            kModFaceJewelry = 1 << 25,
            kModChestSecondary = 1 << 26,
            kModShoulder = 1 << 27,
            kModArmLeft = 1 << 28,
            kModArmRight = 1 << 29,
            kModMisc2 = 1 << 30,
            kFX01 = 1 << 31
        }

        public enum ArmorType
        {
            kLightArmor,
            kHeavyArmor,
            kClothing
        }

        public BipedObjectSlot BipedObjectSlots;

        public ArmorType ArmorTypes;
    }
}
