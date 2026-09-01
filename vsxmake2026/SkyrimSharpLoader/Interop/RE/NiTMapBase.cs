using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class NiTMapBase<TKey, TValue>(NiTMapBase<TKey, TValue>.Internal* ptr) :
        INiTMapBase, IEnumerable<NiTMapItem<TKey, TValue>>,
        IFromNative<NiTMapBase<TKey, TValue>, NiTMapBase<TKey, TValue>.Internal>
        where TKey : unmanaged where TValue : unmanaged
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal void** Vtable;

            internal uint Capacity;

            internal uint pad0C;

            internal NiTMapItem<TKey, TValue>.Internal** Data;

            internal uint Size;

            internal void ClearValue() { }

            internal NiTMapItem<TKey, TValue>.Internal* MallocValue() => (NiTMapItem<TKey, TValue>.Internal*)nint.Zero;

            internal void FreeValue() { }
        }

        internal unsafe struct Enumerator(Internal* native) : IEnumerator<NiTMapItem<TKey, TValue>>
        {
            private readonly Internal* _map = native;

            private uint _index = 0;

            private NiTMapItem<TKey, TValue>.Internal* _currentPtr;

            public NiTMapItem<TKey, TValue> Current { get; private set; }

            readonly object IEnumerator.Current => Current;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                if (_map == null || _map->Data == null)
                    return false;

                if (_currentPtr != null)
                    _currentPtr = _currentPtr->Next;

                while (_currentPtr == null && _index < _map->Capacity)
                    _currentPtr = _map->Data[_index++];

                if (_currentPtr != null)
                {
                    Current = new(_currentPtr);

                    return true;
                }

                Current = null;

                return false;
            }

            public void Reset()
            {
                Current = null;

                _index = 0;
            }

            public void Dispose() { }
        }

        public Dictionary<string, Vtable> Vtables => [new("NiTMapBase", ((Internal*)Native)->Vtable)];

        public nint Native { get; } = new(ptr);

        public static implicit operator NiTMapBase<TKey, TValue>(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(NiTMapBase<TKey, TValue> instance) => (Internal*)instance.Native;

        public static NiTMapBase<TKey, TValue> FromNative(nint ptr) => new((Internal*)ptr);

        public TValue this[TKey key]
        {
            get
            {
                if (TryGetValue(key, out var value))
                    return value;

                throw new KeyNotFoundException();
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default;

            if (Native == nint.Zero || ((Internal*)Native)->Data == null)
                return false;

            var index = this.HashFunction(key);

            var item = ((Internal*)Native)->Data[index];

            while (item != null)
            {
                if (this.KeyEqual(key, item->key))
                {
                    value = item->value;
                    return true;
                }

                item = item->Next;
            }

            return false;
        }

        internal Enumerator GetEnumerator() => new((Internal*)Native);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<NiTMapItem<TKey, TValue>> IEnumerable<NiTMapItem<TKey, TValue>>.GetEnumerator() => GetEnumerator();
    }

    public interface INiTMapBase : IFromNative, IHaveVtable;

    public unsafe static class NiTMapBaseExt
    {
        public static uint HashFunction<TKey, TValue>(this NiTMapBase<TKey, TValue> mapBase, TKey key) where TKey : unmanaged where TValue : unmanaged
            => mapBase.Native.CallVirt<TKey, uint>(key, 0x1, mapBase.Vtables["NiTMapBase"]);

        public static bool KeyEqual<TKey, TValue>(this NiTMapBase<TKey, TValue> mapBase, TKey key1, TKey key2) where TKey : unmanaged where TValue : unmanaged
            => mapBase.Native.CallVirt<TKey, TKey, bool>(key1, key2, 0x2, mapBase.Vtables["NiTMapBase"]);

        public static void AssignValue<TKey, TValue>(this NiTMapBase<TKey, TValue> mapBase) where TKey : unmanaged where TValue : unmanaged
            => mapBase.Native.CallVoidVirt(0x3, mapBase.Vtables["NiTMapBase"]);
    }

    public unsafe readonly struct NiTMapItem<TKey, TValue>(NiTMapItem<TKey, TValue>.Internal* ptr) :
        INiTMapItem, IFromNative<NiTMapItem<TKey, TValue>, NiTMapItem<TKey, TValue>.Internal>
        where TKey : unmanaged where TValue : unmanaged
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct Internal
        {
            internal Internal* Next;

            internal TKey key;

            internal TValue value;
        }

        public NiTMapItem<TKey, TValue>? Next
        {
            get
            {
                if (Native == 0)
                    return null;

                var nextPtr = ((Internal*)Native)->Next;

                return nextPtr != null ? nextPtr : null;
            }
        }

        public nint Native { get; } = new(ptr);

        public static implicit operator NiTMapItem<TKey, TValue>(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(NiTMapItem<TKey, TValue> instance) => (Internal*)instance.Native;

        public static NiTMapItem<TKey, TValue> FromNative(nint ptr) => new((Internal*)ptr);
    }

    public interface INiTMapItem;
}
