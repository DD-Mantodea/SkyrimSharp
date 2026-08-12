using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.NativeStructures;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class BSIRagdollDriver
    {
        public struct Internal
        {
            internal void** Vtable;

            internal bool HasRagdoll() => this.CallVirt<Internal, bool>(0x1);

            internal bool AddRagdollToWorld() => this.CallVirt<Internal, bool>(0x2);

            internal bool RemoveRagdollFromWorld() => this.CallVirt<Internal, bool>(0x3);

            internal void SetWorld(bhkWorld.Internal* a_world) => this.CallVoidVirt<Internal, Ptr<bhkWorld.Internal>>(a_world, 0x4);

            internal void ResetRagdoll() => this.CallVoidVirt(0x5);

            internal void Unk_06() => this.CallVoidVirt(0x6);

            internal void SetRagdollConstraintsFromBhkConstraints() => this.CallVoidVirt(0x7);

            internal void SetMotionType(hkpMotion.Internal.MotionType a_motionType) => this.CallVoidVirt(0x8);

            internal void Unk_09() => this.CallVoidVirt(0x9);

            internal void ToggleSyncOnUpdate(bool a_disable) => this.CallVoidVirt(a_disable, 0xA);

            internal void Unk_0B() => this.CallVoidVirt(0xB);

            internal void ToggleConstraints(bool a_disable) => this.CallVoidVirt(a_disable, 0xC);

            internal void Unk_0D() => this.CallVoidVirt(0xD);
        }
    }
}
