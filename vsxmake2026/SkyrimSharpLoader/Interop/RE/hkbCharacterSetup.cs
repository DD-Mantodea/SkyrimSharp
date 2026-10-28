using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct hkbCharacterSetup
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x68)]
        public struct Internal
        {
            internal hkReferencedObject.Internal Base;

            internal hkArray<hkRefPtr<hkaSkeletonMapper>> RetargetingSkeletonMappers;

            internal hkRefPtr<hkaSkeleton> AnimationSkeleton;

            internal hkRefPtr<hkaSkeletonMapper> RagdollToAnimationSkeletonMapper;

            internal hkRefPtr<hkaSkeletonMapper> AnimationToRagdollSkeletonMapper;

            internal hkRefPtr<hkbAnimationBindingSet> AnimationBindingSet;

            internal hkRefPtr<hkbCharacterData> Data;

            internal hkRefPtr<hkaSkeleton> UnscaledAnimationSkeleton;

            internal hkRefPtr<hkaMirroredSkeleton> MirroredSkeleton;

            internal hkRefPtr<hkbSymbolIdMap> CharacterPropertyIdMap;

            internal hkCriticalSection* CriticalSection;
        }
    }
}
