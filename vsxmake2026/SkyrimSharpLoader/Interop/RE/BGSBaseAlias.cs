using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSBaseAlias(BGSBaseAlias.Internal* ptr)
        : IBGSBaseAlias, IFromNative<BGSBaseAlias, BGSBaseAlias.Internal>
    {
        public enum FILL_TYPE
        {
            kConditions = 0,
            kForced = 1,
            kFromAlias = 2,
            kFromEvent = 3,
            kCreated = 4,
            kFromExternal = 5,
            kUniqueActor = 6,
            kNearAlias = 7
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal void** Vtable;
            internal BSFixedString AliasName;
            internal TESQuest.Internal* OwningQuest;
            internal uint AliasID;
            internal uint Flags;
            internal ushort FillType;
            internal ushort pad22;
            internal uint pad24;
        }

        static BGSBaseAlias()
        {
            _vtables.Add("BGSBaseAlias", VTABLES.Get("VTABLE_BGSBaseAlias", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator BGSBaseAlias(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BGSBaseAlias instance) => (Internal*)instance.Native.ToPointer();

        public static BGSBaseAlias FromNative(nint ptr) => new((Internal*)ptr);

        public TESQuest.Internal* OwningQuest => ((Internal*)Native.ToPointer())->OwningQuest;

        public uint AliasID => ((Internal*)Native.ToPointer())->AliasID;

        public FILL_TYPE FillType => (FILL_TYPE)((Internal*)Native.ToPointer())->FillType;
    }

    public static unsafe class BGSBaseAliasExt
    {
        public static bool IsEssential<T>(this T alias) where T : IBGSBaseAlias, IFromNative
            => ((((BGSBaseAlias.Internal*)alias.Native)->Flags >> 6) & 1) != 0;

        public static bool IsProtected<T>(this T alias) where T : IBGSBaseAlias, IFromNative
            => ((((BGSBaseAlias.Internal*)alias.Native)->Flags >> 10) & 1) != 0;

        public static bool IsQuestObject<T>(this T alias) where T : IBGSBaseAlias, IFromNative
            => ((((BGSBaseAlias.Internal*)alias.Native)->Flags >> 2) & 1) != 0;
    }

    public unsafe interface IBGSBaseAlias : IFromNative, IHaveVtable;
}
