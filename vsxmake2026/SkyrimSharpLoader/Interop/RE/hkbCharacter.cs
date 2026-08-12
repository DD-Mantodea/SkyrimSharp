using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkbCharacter : IhkbCharacter
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0xA0)]
        public struct Internal
        {
            internal hkReferencedObject.Internal Base;

            internal hkArray<Ptr<Internal>> NearbyCharacters;

            internal short CurrentLOD;

            internal short NumTracksInLOD;

            internal uint pad24;

            internal hkStringPtr Name;

            internal hkRefPtr<hkbRagdollDriver.Internal> RagdollDriver;

            internal hkRefVariant CharacterControllerDriver;

            internal hkRefVariant FootIkDriver;

            internal hkRefVariant HandIkDriver;

            internal hkRefPtr<hkbCharacterSetup.Internal> Setup;

            internal hkRefPtr<hkbBehaviorGraph.Internal> behaviorGraph;

            internal hkRefPtr<hkbProjectData> projectData;

            internal hkRefVariant AnimationBindingSet;

            internal hkRefVariant RaycastInterface;

            internal hkRefVariant World;

            internal hkRefVariant EventQueue;

            internal hkRefVariant WorldFromModel;

            internal void** PoseLocal;

            internal int NumPoseLocal;

            internal bool DeleteWorldFromModel;

            internal bool DeletePoseLocal;

            internal ushort pad9E;
        }
    }

    public interface IhkbCharacter : IhkReferencedObject;
}
