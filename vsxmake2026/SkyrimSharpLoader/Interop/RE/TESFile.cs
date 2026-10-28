using SkyrimSharpLoader.Internal;
using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using SkyrimSharpLoader.Interop.REX.W32;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe struct TESFile(TESFile.Internal* ptr) : IFromNative<TESFile, TESFile.Internal>
    {
        [Flags]
        public enum Error : uint
        {
            kNone = 0,
            kNotFound = 1,
            kNoFile = 2,
            kNoForm = 3,
            kNoChunk = 4,
            kNoID = 5,
            kBadFile = 6,
            kBadID = 7,
            kFormOpen = 8,
            kFileOpen = 9,
            kWriteFailure = 10,
            kInvalidFile = 11,
            kFileInUse = 12,
            kCreateFailure = 13
        }

        [Flags]
        public enum RecordFlag : uint
        {
            kNone = 0,
            kMaster = 1 << 0,
            kAltered = 1 << 1,
            kChecked = 1 << 2,
            kActive = 1 << 3,
            kOptimizedFile = 1 << 4,
            kTempIDOwner = 1 << 5,
            kDelocalized = 1 << 7,
            kPrecalcDataOnly = 1 << 8,
            kSmallFile = 1 << 9
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Internal
        {
            internal Error LastError;
            internal uint Pad004;
            internal Internal* ThreadSafeParent;
            internal void* ThreadSafeFileMap;
            internal ulong Unk018;
            internal ulong Unk020;
            internal byte Unk028;
            internal byte Unk029;
            internal ushort Pad02A;
            internal uint Pad02C;
            internal void* LockedFile;
            internal void* File;
            internal void* FormUserDataBitArray;
            internal void* FormVersionBitArray;
            internal void* FormIDBitArray;
            internal fixed byte FileName[260];
            internal fixed byte Path[260];
            internal byte* Buffer;
            internal uint BufferAllocSize;
            internal uint FirstCellOffset;
            internal uint CurrCellOffset;
            internal uint Unk274;
            internal void* CurrCell;
            internal uint CurrRefOffset;
            internal FORM CurrentForm;
            internal uint CurrentChunkID;
            internal uint ActualChunkSize;
            internal uint Filesize;
            internal uint FileOffset;
            internal uint FormOffset;
            internal uint ChunkOffset;
            internal FORM SaveForm;
            internal uint SaveFormOffset;
            internal ulong SaveChunkOffset;
            internal ulong Unk2D8;
            internal ulong Unk2E0;
            internal byte Unk2E8;
            internal byte IsBigEndian;
            internal byte Unk2EA;
            internal byte Pad2EB;
            internal WIN32_FIND_DATAA FileData;
            internal float Version;
            internal uint FormCount;
            internal uint NextFormID;
            internal RecordFlag RecordFlags;
            internal uint Pad43C;
            internal BSSimpleList<Ptr<byte>> Masters;
            internal BSSimpleList<Ptr<ulong>> MastersData;
            internal uint MasterCount;
            internal uint Pad464;
            internal Internal** MasterPtrs;
            internal FILETIME DeletedFormTime;
            internal byte CompileIndex;
            internal byte Pad479;
            internal ushort SmallFileCompileIndex;
            internal uint Pad47C;
            internal BSString CreatedBy;
            internal BSString Summary;
            internal byte* DecompressedFormBuffer;
            internal uint DecompressedFormBufferSize;
            internal uint Pad4AC;
            internal void* ReservedDecompressionBuffer;
            internal uint ReservedDecompressionBufferSize;
            internal uint Pad4BC;
            internal void* InteriorCellOffsetData;
        }

        public nint Native { get; } = new(ptr);

        public static implicit operator TESFile(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESFile instance) => (Internal*)instance.Native.ToPointer();

        public static TESFile FromNative(nint ptr) => new((Internal*)ptr);

        public static TESFile LookupPluginByID(uint formID) => new(Form.LookupPluginByID(formID));

        public readonly string Filename
        {
            get
            {
                var self = (Internal*)Native.ToPointer();

                return Marshal.PtrToStringUTF8((nint)self->FileName) ?? string.Empty;
            }
        }

        public readonly string Path
        {
            get
            {
                var self = (Internal*)Native.ToPointer();

                return Marshal.PtrToStringUTF8((nint)self->Path) ?? string.Empty;
            }
        }

        public readonly Error LastError
        {
            get
            {
                var self = (Internal*)Native.ToPointer();

                return self->LastError;
            }
        }

        public readonly bool IsLight
        {
            get
            {
                var self = (Internal*)Native.ToPointer();

                return (self->RecordFlags & RecordFlag.kSmallFile) != 0;
            }
        }

        public readonly bool IsLocalized
        {
            get
            {
                var self = (Internal*)Native.ToPointer();

                return (self->RecordFlags & RecordFlag.kDelocalized) != 0;
            }
        }

        public readonly byte CompileIndex
        {
            get
            {
                var self = (Internal*)Native.ToPointer();

                return self->CompileIndex;
            }
        }

        public readonly ushort SmallFileCompileIndex
        {
            get
            {
                var self = (Internal*)Native.ToPointer();

                return self->SmallFileCompileIndex;
            }
        }

        public readonly uint MasterCount
        {
            get
            {
                var self = (Internal*)Native.ToPointer();

                return self->MasterCount;
            }
        }

        public readonly uint GetCombinedIndex()
        {
            var self = (Internal*)Native.ToPointer();

            return (uint)(self->CompileIndex + self->SmallFileCompileIndex);
        }

        public readonly uint GetPartialIndex()
        {
            var self = (Internal*)Native.ToPointer();

            return !IsLight ? self->CompileIndex : (0xFE000u | self->SmallFileCompileIndex);
        }

        public readonly uint GetFormID(uint formLower)
        {
            var self = (Internal*)Native.ToPointer();

            return ((uint)self->CompileIndex << 24) | (formLower & 0xFFFFFFu);
        }

        public readonly List<string> GetMasters()
        {
            var result = new List<string>();
            var self = (Internal*)Native.ToPointer();
            var node = &self->Masters.ListHead;

            while (node != null)
            {
                if ((nint)node->Item != 0)
                {
                    var name = Marshal.PtrToStringUTF8(node->Item);

                    if (name != null)
                        result.Add(name);
                }

                node = node->Next;
            }

            return result;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FORM
    {
        internal uint Form;
        internal uint Length;
        internal uint Flags;
        internal uint FormID;
        internal uint VersionControl;
        internal ushort FormVersion;
        internal ushort VcVersion;
    }
}
