using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x90)]
    public unsafe struct hkbNodeInfo
    {
        internal void* unk00;

        internal long unk08;

        internal long unk10;

        internal void* unk18;

        internal fixed char unk20[48];

        internal hkbNode.Internal* NodeTemplate;

        internal hkbNode.Internal* NodeClone;

        internal hkbBehaviorGraph.Internal* Behavior;

        internal long unk68;

        internal long unk70;

        internal long unk78;

        internal long unk80;

        internal bool unk88;
    }
}
