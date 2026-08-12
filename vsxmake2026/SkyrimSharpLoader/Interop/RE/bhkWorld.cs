using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class bhkWorld
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0xC600)]
        public struct Internal
        {
            internal bhkSerializable.Internal Base;

            internal byte* unk0020;

            internal byte* unk0340;

            internal byte* unk6470;

            internal BSTArray<nint>.Internal unkC500;

            internal BSTArray<nint>.Internal unkC518;

            internal BSTArray<nint>.Internal unkC530;

            internal BSTArray<nint>.Internal unkC548;

            internal ulong unkC560;

            internal uint unkC568;

            internal float unkC56C;

            internal void* ConstraintProjector; // bhkConstraintProjector

            internal ulong unkC578;

            internal uint unkC580;

            internal float unkC584;

            internal ulong unkC588;

            internal ulong unkC590;

            internal BSReadWriteLock WorldLock;

            internal BSReadWriteLock unkC5A0;

            internal ulong unkC5A8;

            internal hkVector4 unkC5B0;

            internal ulong unkC5C0;

            internal void* AcousticSpaceListener; // BGSAcousticSpaceListener

            internal void* SuspendInactiveAgentsUtil; // hkpSuspendInactiveAgentsUtil

            internal uint unkC5D8;

            internal uint unkC5DC;

            internal uint unkC5E0;

            internal uint unkC5E4;

            internal uint unkC5E8;

            internal uint unkC5EC;

            internal float Tau;

            internal float Damping;

            internal byte unkC5F8;

            internal bool ToggleCollision;

            internal ushort unkC5FA;

            internal ushort unkC5FC;

            internal ushort unkC5FE;
        }
    }
}
