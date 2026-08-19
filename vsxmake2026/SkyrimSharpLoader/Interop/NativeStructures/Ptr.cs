using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.NativeStructures
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Ptr<T>(nint native) : IEquatable<Ptr<T>> where T : unmanaged
    {
        private readonly nint Native = native;

        public Ptr(T* native) : this(new nint(native)) { }

        public static implicit operator nint(Ptr<T> ptr) => ptr.Native;

        public static implicit operator T*(Ptr<T> ptr) => (T*)ptr.Native.ToPointer();

        public static implicit operator Ptr<T>(nint ptr) => new(ptr);

        public static implicit operator Ptr<T>(T* ptr) => new(ptr);

        public bool Equals(Ptr<T> other) => Native == other.Native;

        public override bool Equals(object? obj) => obj is Ptr<T> other && Equals(other);

        public override int GetHashCode() => Native.GetHashCode();

        public static bool operator ==(Ptr<T> left, Ptr<T> right) => left.Equals(right);

        public static bool operator !=(Ptr<T> left, Ptr<T> right) => !(left == right);
    }
}
