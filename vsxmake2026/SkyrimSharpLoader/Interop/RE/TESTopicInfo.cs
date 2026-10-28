using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct TESTopicInfo(TESTopicInfo.Internal* ptr)
        : ITESTopicInfo, IFromNative<TESTopicInfo, TESTopicInfo.Internal>
    {
        public enum FavorLevel : byte
        {
            kNone = 0,
            kSmall = 1,
            kMedium = 2,
            kLarge = 3
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal TESForm.Internal Base_0;
            internal TESTopic.Internal* ParentTopic;
            internal Internal* DataInfo;
            internal TESCondition ObjConditions;
            internal ushort InfoIndex;
            internal bool SaidOnce;
            internal FavorLevel FavorLevel;
            internal TOPIC_INFO_DATA Data;
            internal uint FileOffset;
            internal uint pad44;
        }

        static TESTopicInfo()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_TESTopicInfo", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_TESTopicInfo", 0));
            _vtables.Add("TESTopicInfo", VTABLES.Get("VTABLE_TESTopicInfo", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator TESTopicInfo(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESTopicInfo instance) => (Internal*)instance.Native.ToPointer();

        public static TESTopicInfo FromNative(nint ptr) => new((Internal*)ptr);

        public TESTopic ParentTopic => ((Internal*)Native.ToPointer())->ParentTopic;

        public TESQuest OwningQuest
        {
            get
            {
                var self = (Internal*)Native.ToPointer();

                if ((nint)self->ParentTopic == 0)
                    return default;

                return self->ParentTopic->OwnerQuest;
            }
        }

        public ushort InfoIndex => ((Internal*)Native.ToPointer())->InfoIndex;

        public bool SaidOnce
        {
            get => ((Internal*)Native.ToPointer())->SaidOnce;
            set => ((Internal*)Native.ToPointer())->SaidOnce = value;
        }

        public FavorLevel Favor => ((Internal*)Native.ToPointer())->FavorLevel;
    }

    public static unsafe class TESTopicInfoExt
    {
        public static nint GetFormEditorID<T>(this T info) where T : ITESTopicInfo, IFromNative
            => info.Native.CallVirt<nint>(0x32, info.Vtables["TESTopicInfo"]);

        public static bool SetFormEditorID<T>(this T info, nint a_str) where T : ITESTopicInfo, IFromNative
            => info.Native.CallVirt<nint, bool>(a_str, 0x33, info.Vtables["TESTopicInfo"]);
    }

    public unsafe interface ITESTopicInfo : ITESForm;
}
