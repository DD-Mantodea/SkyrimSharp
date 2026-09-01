using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    using CopyMap = NiTPointerMap<Ptr<TESForm.Internal>, Ptr<TESForm.Internal>>;

    public unsafe class TESForm(TESForm.Internal* ptr) : ITESForm, IFromNative<TESForm, TESForm.Internal>
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
        }

        static TESForm()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_TESForm", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_TESForm", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator TESForm(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESForm instance) => (Internal*)instance.Native.ToPointer();

        public static TESForm FromNative(nint ptr) => new((Internal*)ptr);
    }

    public interface ITESForm : IBaseFormComponent;

    public unsafe static class TESFormExt
    {
        public static void InitializeData<T>(this T form) where T : ITESForm, IFromNative 
            => form.Native.CallVoidVirt(0x4, form.Vtables["TESForm"]);

        public static void ClearData<T>(this T form) where T : ITESForm, IFromNative
            => form.Native.CallVoidVirt(0x5, form.Vtables["TESForm"]);

        public static bool Load<T>(this T form, TESFile mod) where T : ITESForm, IFromNative
            => form.Native.CallVirt<Ptr<TESFile.Internal>, bool>(mod.Native, 0x6, form.Vtables["TESForm"]);

        public static bool LoadPartial<T>(this T form, TESFile.Internal* a_mod) where T : ITESForm, IFromNative
            => form.Native.CallVirt<Ptr<TESFile.Internal>, bool>(a_mod, 0x7, form.Vtables["TESForm"]);

        public static bool LoadEdit<T>(this T form, TESFile.Internal* a_mod) where T : ITESForm, IFromNative
            => form.Native.CallVirt<Ptr<TESFile.Internal>, bool>(a_mod, 0x8, form.Vtables["TESForm"]);

        public static TESForm CreateDuplicateForm<T>(this T form, bool a_createEditorID, CopyMap.Internal* a_copyMap) where T : ITESForm, IFromNative
            => new(form.Native.CallVirt<bool, Ptr<CopyMap.Internal>, Ptr<TESForm.Internal>>(a_createEditorID, a_copyMap, 0x9, form.Vtables["TESForm"]));

        public static bool AddChange<T>(this T form, uint a_changeFlags) where T : ITESForm, IFromNative
            => form.Native.CallVirt<uint, bool>(a_changeFlags, 0xA, form.Vtables["TESForm"]);

        public static void RemoveChange<T>(this T form, uint a_changeFlags) where T : ITESForm, IFromNative
            => form.Native.CallVoidVirt(a_changeFlags, 0xB, form.Vtables["TESForm"]);

        public static bool FindInFileFast<T>(this T form, TESFile.Internal* a_mod) where T : ITESForm, IFromNative
            => form.Native.CallVirt<Ptr<TESFile.Internal>, bool>(a_mod, 0xC, form.Vtables["TESForm"]);

        public static bool Activate<T>(this T form, ITESObjectREFR a_targetRef, ITESObjectREFR a_activatorRef, byte a_arg3, ITESBoundObject a_object, int a_targetCount) where T : ITESForm, IFromNative
            => form.Native.CallVirt<Ptr<TESObjectREFR.Internal>, Ptr<TESObjectREFR.Internal>, byte, Ptr<TESBoundObject.Internal>, int, bool>(
                a_targetRef.Native, a_activatorRef.Native, a_arg3, a_object.Native, a_targetCount, 0x37, form.Vtables["TESForm"]
            );
    }
}
