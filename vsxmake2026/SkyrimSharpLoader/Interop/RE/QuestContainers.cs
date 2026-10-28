using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BSTHashMap<K, V> where K : unmanaged where V : unmanaged
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal ulong pad00;
            internal uint pad08;
            internal uint Capacity;
            internal uint Free;
            internal uint Good;
            internal nint Sentinel;
            internal ulong AllocPad00;
            internal byte* Entries;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BSSimpleList<T> where T : unmanaged
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Node
        {
            internal T Item;
            internal Node* Next;
        }

        internal Node ListHead;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BSString
    {
        internal byte* Data;
        internal ushort Size;
        internal ushort Capacity;
    }
}
