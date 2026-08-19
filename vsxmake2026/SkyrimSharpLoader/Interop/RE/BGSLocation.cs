using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSLocation
    {
        public enum ChangeFlag
        {
            kKeywordData = 1 << 30,
            kCleared = 1 << 31
        }

        public enum RecordFlag
        {
            kDeleted = 1 << 5,
            kIgnored = 1 << 12,
            kCleared = 1 << 31
        }

        public struct KEYWORD_DATA
        {
            public BGSKeyword.Internal* Keyword;

            public float Data;

            public uint pad0C;
        }

        public struct Internal
        {
            internal TESForm.Internal Base_0;

            internal TESFullName.Internal Base_1;

            internal BGSKeywordForm.Internal Base_2;

            internal Internal* ParentLoc;

            internal void* UnreportedCrimeFaction;

            internal void* MusicType;

            internal ObjectRefHandle WorldLocMarker;

            internal float WorldLocRadius;

            internal ObjectRefHandle HorseLocMarker;

            internal uint pad6C;

            internal BSTArray<SpecialRefData>.Internal SpecialRefs;

            internal BSTArray<UniqueNPCData>.Internal UniqueNPCs;

            internal OverrideData* OverrideData;

            internal NiPointer<QueuePromoteLocationReferencesTask> PromoteRefsTask;

            internal BSTArray<ObjectRefHandle>.Internal PromotedRef;

            internal volatile int LoadedCount;

            internal uint FileOffset;

            internal BSTArray<KEYWORD_DATA> KeywordData;

            internal uint LastChecked;

            internal bool Cleared;

            internal bool EverCleared;

            internal ushort padEE;
        }
    }

    public unsafe struct QueuePromoteLocationReferencesTask;

    public unsafe struct UnloadedRefData
    {
        public uint RefID;

        public uint ParentSpaceID;

        public uint CellKey;
    }

    public unsafe struct SpecialRefData
    {
        public BGSLocationRefType.Internal* Type;

        public UnloadedRefData RefData;

        public uint pad14;
    }

    public unsafe struct UniqueNPCData
    {
        public Actor.Internal* Actor;

        public uint RefID;

        public uint pad0C;

        public BGSLocation.Internal* EditorLoc;
    }

    [StructLayout(LayoutKind.Sequential, Size = 0x48)]
    public unsafe struct OverrideData
    {
        BSTArray<UnloadedRefData>.Internal AddedData;
    }
}
