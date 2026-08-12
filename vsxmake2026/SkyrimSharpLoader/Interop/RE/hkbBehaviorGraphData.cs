using static SkyrimSharpLoader.Interop.RE.hkbBehaviorGraphData;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkbBehaviorGraphData : IhkbBehaviorGraphData
    {
        public struct Internal
        {
            internal hkReferencedObject.Internal Base;

            internal void** Vtable;

            internal hkArray<float> AttributeDefaults;

            internal hkArray<hkbVariableInfo> VariableInfos;

            internal hkArray<hkbVariableInfo> CharacterPropertyInfos;

            internal hkArray<hkbVariableInfo> EventInfos;

            internal hkArray<hkbVariableBounds> VariableBounds;

            internal ulong unk60;

            internal ulong unk68;

            internal hkbVariableValueSet* VariableInitialValues;

            internal hkRefPtr<hkbBehaviorGraphStringData> StringData;
        }

        public interface IhkbBehaviorGraphData : IhkReferencedObject;
    }
}
