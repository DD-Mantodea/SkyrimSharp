using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    using CopyMap = NiTPointerMap<Ptr<TESForm.Internal>, Ptr<TESForm.Internal>>;

    public unsafe readonly struct TESForm : ITESForm
    {
        [Flags]
        public enum ChangeFlags : uint
        {
            kCreated = 0,
            kFlags = 1 << 0
        }

        [Flags]
        public enum RecordFlags : uint
        {
            kDestructible = 1 << 0,
            kMaster = 1 << 0,
            kUnlocked = 1 << 0,

            kAltered = 1 << 1,
            kNonPlayable = 1 << 2,
            kInitialized = 1 << 3,
            kNonOccluder = 1 << 4,
            kDeleted = 1 << 5,

            kBorderRegion = 1 << 6,
            kGlobalConstant = 1 << 6,
            kHasSpokenFlag = 1 << 6,
            kKnown = 1 << 6,
            kInPlaceableWater = 1 << 6,

            kFireOff = 1 << 7,
            kMustUpdate = 1 << 8,
            kOnLocalMap = 1 << 9,
            kPersistent = 1 << 10,

            kDisabled = 1 << 11,
            kUsedAsMovingPlatform = 1 << 11,

            kIgnored = 1 << 12,

            kEmpty = 1 << 13,
            kResetDestruction = 1 << 13,

            kTemporary = 1 << 14,
            kVisibleWhenDistant = 1 << 15,
            kRandomAnim = 1 << 16,
            kDangerous = 1 << 17,
            kHasCurrents = 1 << 19,
            kIgnoreFriendlyHits = 1 << 20,
            kStillLoading = 1 << 21,
            kFormRetainsID = 1 << 22,
            kDestroyed = 1 << 23,

            kUnk24 = 1 << 24,

            kNoAIAcquire = 1 << 25,
            kObstacle = 1 << 25,

            kVATSTargetOverride = 1 << 26,
            kDisableFade = 1 << 27,

            kReflectedByAutoWater = 1 << 28,
            kShowOnWorldMap = 1 << 28,

            kChildCanUse = 1 << 29
        }

        [Flags]
        public enum InGameFormFlag : ushort
        {
            kNone = 0,
            kWantsDelete = 1 << 0,
            kForcedPersistent = 1 << 1,
            kNoFavorAllowed = 1 << 4,
            kIsSkyObject = 1 << 5,
            kRefOriginalPersistent = 1 << 6,
            kRefPermanentlyDeleted = 1 << 7
        }

        [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 0x20)]
        public struct Internal
        {
            internal BaseFormComponent.Internal Base;

            internal TESFileContainer SourceFiles;

            internal uint FormFlags;

            internal uint FormID;

            internal InGameFormFlag InGameFormFlags;

            internal FormType FormType;

            internal byte pad1B;

            internal uint pad1C;

            internal void InitializeDataComponent() => Base.InitializeDataComponent();

            internal void ClearDataComponent() => Base.ClearDataComponent();

            internal void CopyComponent(BaseFormComponent.Internal* a_rhs) => Base.CopyComponent(a_rhs);

            internal void InitializeData() => this.CallVoidVirt(0x4);

            internal void ClearData() => this.CallVoidVirt(0x5);

            internal bool Load(TESFile.Internal* a_mod) => this.CallVirt<Internal, Ptr<TESFile.Internal>, bool>(a_mod, 0x6);

            internal bool LoadPartial(TESFile.Internal* a_mod) => this.CallVirt<Internal, Ptr<TESFile.Internal>, bool>(a_mod, 0x7);

            internal bool LoadEdit(TESFile.Internal* a_mod) => this.CallVirt<Internal, Ptr<TESFile.Internal>, bool>(a_mod, 0x8);

            internal Internal* CreateDuplicateForm(bool a_createEditorID, CopyMap.Internal* a_copyMap) => this.CallVirt<Internal, bool, Ptr<CopyMap.Internal>, Ptr<Internal>>(a_createEditorID, a_copyMap, 0x9);

            internal bool AddChange(uint a_changeFlags) => this.CallVirt<Internal, uint, bool>(a_changeFlags, 0xA);

            internal void RemoveChange(uint a_changeFlags) => this.CallVoidVirt(a_changeFlags, 0xB);

            internal bool FindInFileFast(TESFile.Internal* a_mod) => this.CallVirt<Internal, Ptr<TESFile.Internal>, bool>(a_mod, 0xC);

            //internal bool CheckSaveGame(BGSSaveFormBuffer)

            internal bool Activate(TESObjectREFR.Internal* a_targetRef, TESObjectREFR.Internal* a_activatorRef, byte a_arg3, TESBoundObject.Internal* a_object, int a_targetCount)
                => this.CallVirt<Internal, Ptr<TESObjectREFR.Internal>, Ptr<TESObjectREFR.Internal>, byte, Ptr<TESBoundObject.Internal>, int, bool>
                (
                    a_targetRef, a_activatorRef, a_arg3, a_object, a_targetCount, 0x37
                );
        }
    }

    public interface ITESForm : IBaseFormComponent;
}
