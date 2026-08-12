using SkyrimSharpLoader.Interop.Interfaces;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe class BSStaticArray<T>(BSStaticArray<T>.Internal* ptr) : IEnumerable<T>, IFromNative<BSStaticArray<T>, BSStaticArray<T>.Internal> where T : unmanaged
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct Internal
        {
            internal T* Data;

            internal uint Size;
        }

        public struct Enumerator(Internal* native) : IEnumerator<T>
        {
            public readonly Internal* Array = native;

            private int _index = -1;

            public T Current { get; private set; } = default;

            readonly object IEnumerator.Current => Current;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                if (Array == null || Array->Data == null || _index + 1 >= Array->Size)
                    return false;

                _index++;

                Current = Array->Data[_index];

                return true;
            }

            public void Reset()
            {
                _index = -1;

                Current = default;
            }

            public void Dispose() { }
        }

        public nint Native { get; } = new(ptr);

        public static implicit operator BSStaticArray<T>(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BSStaticArray<T> instance) => (Internal*)instance.Native;

        public static BSStaticArray<T> FromNative(nint ptr) => new((Internal*)ptr);

        public uint Size
        {
            get => ((Internal*)Native.ToPointer())->Size;

            set => ((Internal*)Native.ToPointer())->Size = value;
        }

        public Enumerator GetEnumerator() => new((Internal*)Native);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        public ref T this[uint index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var internalPtr = (Internal*)Native.ToPointer();

                if (internalPtr == null || internalPtr->Data == null || index >= internalPtr->Size)
                    throw new IndexOutOfRangeException($"BSStaticArray index out of range.");

                return ref internalPtr->Data[index];
            }
        }
    }
}
