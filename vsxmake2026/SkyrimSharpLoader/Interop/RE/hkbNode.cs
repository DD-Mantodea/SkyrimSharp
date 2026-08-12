namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct hkbNode : IhkbNode
    {
        public struct Internal
        {
            public enum GetChildrenFlagBits
            {
                kActiveOnly = 1 << 0,
                kGeneratorsOnly = 1 << 1,
                kIgnoreReferencedBehaviour = 1 << 2
            }

            [Flags]
            public enum CloneState
            {
                kDefault = 0,
                kTemplate = 1,
                kClone = 2,
                kShareable = 3
            }

            internal hkbBindable.Internal Base;

            internal void** Vtable;

            internal ulong UserData;

            internal hkStringPtr Name;

            internal ushort ID;

            internal CloneState CloneStates;

            internal byte pad43;

            internal uint pad44;
        }
    }

    public interface IhkbNode : IhkbBindable;
}
