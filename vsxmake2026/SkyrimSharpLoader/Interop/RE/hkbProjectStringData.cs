namespace SkyrimSharpLoader.Interop.RE
{
    public struct hkbProjectStringData : IhkReferencedObject
    {
        internal hkArray<hkStringPtr> AnimationFilenames;

        internal hkArray<hkStringPtr> BehaviorFilenames;

        internal hkArray<hkStringPtr> CharacterFilenames;

        internal hkArray<hkStringPtr> EventNames;

        internal hkStringPtr AnimationPath;

        internal hkStringPtr BehaviorPath;

        internal hkStringPtr CharacterPath;

        internal hkStringPtr ScriptsPath;

        internal hkStringPtr FullPathToSource;

        internal hkStringPtr RootPath;
    }
}
