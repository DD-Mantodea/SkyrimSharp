using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct GlobalOrFloat
    {
        [FieldOffset(0)] internal TESGlobal.Internal* Global;
        [FieldOffset(0)] internal float Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FUNCTION_DATA
    {
        internal uint Function;
        internal uint Param1;
        internal uint Param2;
        internal uint unk0C;
        internal uint unk10;
        internal uint unk14;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CONDITION_ITEM_DATA
    {
        internal GlobalOrFloat ComparisonValue;
        internal ObjectRefHandle RunOnRef;
        internal uint DataID;
        internal FUNCTION_DATA FunctionData;
        internal byte Flags;
        internal byte Object;
        internal ushort pad32;
        internal uint pad34;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TESConditionItem
    {
        internal TESConditionItem* Next;
        internal CONDITION_ITEM_DATA Data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TESCondition
    {
        internal TESConditionItem* Head;
    }
}
