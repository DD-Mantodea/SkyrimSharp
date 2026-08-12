using SkyrimSharpLoader.Interop.Extensions;

namespace SkyrimSharpLoader.Interop.RE
{
    public class TESFullName : ITESFullName
    {
        public struct Internal
        {
            internal BaseFormComponent.Internal Base;

            internal BSFixedString FullName;

            internal nint GetFullName() => this.CallVirt<Internal, nint>(0x4);
        }
    }

    public interface ITESFullName : IBaseFormComponent;
}
