namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct hkbBehaviorGraphStringData : IhknBehaviorGraphStringData
    {
        internal hkReferencedObject.Internal Base;

        internal void** Vtable;

        internal hkArray<hkStringPtr> EventNames;

        internal hkArray<hkStringPtr> AttributeNames;

        internal hkArray<hkStringPtr> VariableNames;

        internal hkArray<hkStringPtr> CharacterPropertyNames;
    }

    public interface IhknBehaviorGraphStringData : IhkReferencedObject;
}
