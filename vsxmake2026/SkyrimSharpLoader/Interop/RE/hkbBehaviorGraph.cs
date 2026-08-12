namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkbBehaviorGraph : IhkbBehaviorGraph
    {
        public struct Internal
        {
            [Flags]
            public enum VariableMode
            {
                kDiscardWhenActive = 0,
                kMaintainValuesWhenInactive = 1
            }

            internal hkbGenerator.Internal Base;

            internal void** Vtable;

            internal VariableMode VariableModes;

            internal byte pad49;

            internal ushort pad4A;

            internal uint pad4C;

            internal hkArray<hkRefVariant> UniqueIDPool;

            internal hkRefVariant IdToStateMachineTemplateMap;

            internal hkArray<hkRefVariant> MirroredExternalIDMap;
            internal hkRefVariant PseudoRandomGenerator;
            internal hkRefPtr<hkbGenerator.Internal> RootGenerator;
            internal hkRefPtr<hkbBehaviorGraphData.Internal> Data;
            internal hkRefVariant RootGeneratorClone;
            internal hkArray<hkbNodeInfo>* ActiveNodes;
            internal hkRefVariant ActiveNodeTemplateToIndexMap;
            internal hkRefVariant ActiveNodesChildrenIndices;
            internal hkRefVariant GlobalTransitionData;
            internal hkRefVariant EventIDMap;
            internal hkRefVariant AttributeIDMap;
            internal hkRefVariant VariableIDMap;
            internal hkRefVariant CharacterPropertyIDMap;
            internal hkRefVariant VariableValueSet;
            internal hkRefVariant NodeTemplateToCloneMap;
            internal hkRefVariant NodeCloneToTemplateMap;
            internal hkRefVariant StateListenerTemplateToCloneMap;
            internal hkRefVariant NodePartitionInfo;
            internal int NumIntermediateOutputs;
            internal int pad104;
            internal hkArray<hkRefVariant> Jobs;
            internal hkArray<hkRefVariant> AllPartitionMemory;
            internal short NumStaticNodes;
            internal short NextUniqueID;
            internal bool IsActive;
            internal bool IsLinked;
            internal bool UpdateActiveNodes;
            internal bool StateOrTransitionChanged;
        }
    }

    public interface IhkbBehaviorGraph : IhkbGenerator;
}
