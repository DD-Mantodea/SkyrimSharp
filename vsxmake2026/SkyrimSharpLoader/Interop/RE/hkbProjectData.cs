namespace SkyrimSharpLoader.Interop.RE
{
    public struct hkbProjectData : IhkReferencedObject
    {
        internal hkReferencedObject.Internal Base;

        internal hkVector4 WorldUpWS;

        internal hkRefPtr<hkbProjectStringData> StringData;

        internal byte DefaultEventNode;
    }
}
