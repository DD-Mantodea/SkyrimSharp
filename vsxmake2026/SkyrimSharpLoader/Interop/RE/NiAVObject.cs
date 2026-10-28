using SkyrimSharpLoader.Interop.Interfaces;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct NiAVObject(NiAVObject.Internal* ptr) : IFromNative<NiAVObject, NiAVObject.Internal>
    {
        public struct Internal
        {
            [Flags]
            public enum Flag
            {
                kNone = 0,
                kHidden = 1 << 0,
                kSelectiveUpdate = 1 << 1,
                kSelectiveUpdateTransforms = 1 << 2,
                kSelectiveUpdateController = 1 << 3,
                kSelectiveUpdateRigid = 1 << 4,
                kDisplayObject = 1 << 5,
                kDisableSorting = 1 << 6,
                kSelectiveUpdateTransformsOverride = 1 << 7,
                kSaveExternalGeometryData = 1 << 9,
                kNoDecals = 1 << 10,
                kAlwaysDraw = 1 << 11,
                kPreProcessedNode = 1 << 12,
                kFixedBound = 1 << 13,
                kTopFadeNode = 1 << 14,
                kIgnoreFade = 1 << 15,
                kNoAnimSyncX = 1 << 16,
                kNoAnimSyncY = 1 << 17,
                kNoAnimSyncZ = 1 << 18,
                kNoAnimSyncS = 1 << 19,
                kNotVisible = 1 << 20,
                kNoDismemberValidity = 1 << 21,
                kRenderUse = 1 << 22,
                kShadowReceiver = 1 << 23,
                kHighDetail = 1 << 24,
                kForceUpdate = 1 << 25,
                kAccumulated = 1 << 26,
                kMeshLOD = 1 << 27,
                kUnk28 = 1 << 28,
                kShadowCaster = 1 << 29
            }

            internal NiObjectNET.Internal Base;

            internal NiNode.Internal* Parent;

            internal uint ParentIndex;

            internal uint unk03C;

            internal NiPointer<NiCollisionObject.Internal> CollisionObject;

            internal NiTransform Local;

            internal NiTransform World;

            internal NiTransform PreviousWorld;

            internal NiBound WorldBound;

            internal uint unkF4;

            internal ulong* unkF8;

            internal float FadeAmount;

            internal uint LastUpdatedFrameCounter;

            internal ulong unk108;
        }

        public nint Native { get; } = new(ptr);

        public static implicit operator NiAVObject(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(NiAVObject instance) => (Internal*)instance.Native.ToPointer();

        public static NiAVObject FromNative(nint ptr) => new((Internal*)ptr);
    }
}
