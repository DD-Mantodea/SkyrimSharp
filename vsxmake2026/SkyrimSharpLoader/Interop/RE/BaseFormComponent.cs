using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BaseFormComponent(BaseFormComponent.Internal* ptr) : IBaseFormComponent, IFromNative<BaseFormComponent, BaseFormComponent.Internal>
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x8)]
        public struct Internal
        {
            internal void** Vtable;

            internal void InitializeDataComponent() => this.CallVoidVirt(1);

            internal void ClearDataComponent() => this.CallVoidVirt(2);

            internal void CopyComponent(Internal* a_rhs) => this.CallVoidVirt<Internal, Ptr<Internal>>(a_rhs, 3);
        }

        public nint Native { get; } = new(ptr);

        public static implicit operator BaseFormComponent(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BaseFormComponent instance) => (Internal*)instance.Native.ToPointer();

        public void InitializeDataComponent() => ((Internal*)Native.ToPointer())->InitializeDataComponent();

        public void ClearDataComponent() => ((Internal*)Native.ToPointer())->ClearDataComponent();

        public void CopyComponent(BaseFormComponent component) => ((Internal*)Native.ToPointer())->CopyComponent((Internal*)component.Native.ToPointer());

        public static BaseFormComponent FromNative(nint ptr) => new((Internal*)ptr);
    }

    public interface IBaseFormComponent;
}
