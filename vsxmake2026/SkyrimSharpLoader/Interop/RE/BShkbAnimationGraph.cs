namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class BShkbAnimationGraph
    {
        public struct Internal
        {
            public struct BoneNodeEntry
            {
                internal NiNode.Internal* node;

                internal uint unk08;

                internal uint unk0C;
            }

            internal BSIRagdollDriver.Internal Base_0;

            internal BSIntrusiveRefCounted.Internal Base_1;

            internal BSTEventSource<BSTransformDeltaEvent>.Internal Base_2;

            internal BSTEventSource<BSAnimationGraphEvent.Internal>.Internal Base_3;
        }
    }
}
