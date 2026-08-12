using SkyrimSharpLoader.Interop.NativeStructures;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkaRagdollInstance : IhkaRagdollInstance
    {
        public struct Internal
        {
            internal hkReferencedObject.Internal Base;

            internal void** Vtable;

            internal hkArray<Ptr<hkpRigidBody.Internal>> RigidBodies;

            internal hkArray<Ptr<hkpConstraintInstance.Internal>> Constraints;

            internal hkArray<int> BoneToRigidBodyMap;

            internal hkRefPtr<hkaSkeleton> Skeleton;
        }
    }

    public interface IhkaRagdollInstance : IhkReferencedObject;
}
