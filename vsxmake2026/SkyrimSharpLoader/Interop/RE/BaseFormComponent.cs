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
        }

        static BaseFormComponent()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_BaseFormComponent", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator BaseFormComponent(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BaseFormComponent instance) => (Internal*)instance.Native.ToPointer();

        public static BaseFormComponent FromNative(nint ptr) => new((Internal*)ptr);
    }

    public unsafe interface IBaseFormComponent : IFromNative, IHaveVtable;

    public unsafe static class BaseFormComponentExt
    {
        public static void InitializeDataComponent<T>(this T component) where T : unmanaged, IBaseFormComponent, IFromNative
            => component.Native.CallVoidVirt(0x1, component.Vtables["BaseFormComponent"]);

        public static void ClearDataComponent<T>(this T component) where T : unmanaged, IBaseFormComponent, IFromNative
            => component.Native.CallVoidVirt(0x2, component.Vtables["BaseFormComponent"]);

        public static void CopyComponent<T>(this T component, T rhs) where T : unmanaged, IBaseFormComponent, IFromNative
            => component.Native.CallVoidVirt<Ptr<BaseFormComponent.Internal>>(rhs.Native, 0x3, component.Vtables["BaseFormComponent"]);
    }
}
