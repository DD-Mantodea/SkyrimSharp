using SkyrimSharpLoader.Interop.NativeStructures;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class TESFileArray(TESFileArray.Internal* ptr) :
        BSStaticArray<Ptr<TESFile.Internal>>((BSStaticArray<Ptr<TESFile.Internal>>.Internal*)ptr)
    {
        public new struct Internal
        {
            public BSStaticArray<Ptr<TESFile.Internal>>.Internal Base;
        }
    }
}
