using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct BGSLoadFormData
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x28)]
        public struct Internal
        {
            [Flags]
            internal enum FlagsEnum
            {
                kSkipForm = 1 << 0,
                kFormPending = 1 << 1,
                kRevertOnly = 1 << 2,
                kConstructedForm = 1 << 3,
                kCellChanged = 1 << 4,
                kLoadingPackageFromExtraData = 1 << 5
            }

            internal uint FormID;

            internal uint Size;

            internal uint UncompressedSize;

            internal uint pad0C;

            internal TESForm.Internal* Form; // TESForm

            internal uint ChangeFlags;

            internal uint OldChangeFlags;

            internal FlagsEnum Flags;

            internal byte pad22;

            internal byte Version;
        }
    }

    public interface IBGSLoadFormData;
}
