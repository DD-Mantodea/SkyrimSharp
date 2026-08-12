namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkbGenerator : IhkbGenerator
    {
        public struct Internal
        {
            internal hkbNode.Internal Base;

            internal void** Vtable;
        }
    }

    public interface IhkbGenerator : IhkbNode;
}
