using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSAnimationGraphManager : IBSAnimationGraphManager
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0xB0)]
        public struct Internal
        {
            [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x10)]
            public struct AnimationVariable
            {
                internal BSFixedString Name;

                internal uint Value;
            }

            internal BSTEventSink<BSAnimationGraphEvent.Internal>.Internal Base_0;

            internal BSIntrusiveRefCounted.Internal Base_1;

            internal uint pad0C;

            internal BSTArray<BSTSmartPointer<BSAnimationGraphChannel.Internal>.Internal>.Internal BoundChannels;

            internal BSTArray<BSTSmartPointer<BSAnimationGraphChannel.Internal>.Internal>.Internal BumpedChannels;

            internal BSTSmallArray<BSTSmartPointer<BShkbAnimationGraph.Internal>.Internal>.Internal Graphs;
        }
    }

    public interface IBSAnimationGraphManager :
        IBSTEventSink<BSAnimationGraphEvent.Internal>,
        IBSIntrusiveRefCounted;
}
