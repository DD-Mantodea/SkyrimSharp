using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct TESTopic(TESTopic.Internal* ptr)
        : ITESTopic, IFromNative<TESTopic, TESTopic.Internal>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal TESForm.Internal Base_0;
            internal TESFullName.Internal Base_1;

            internal DIALOGUE_DATA Data;
            internal uint PriorityAndJournalIndex;
            internal BGSDialogueBranch.Internal* OwnerBranch;
            internal TESQuest.Internal* OwnerQuest;
            internal TESTopicInfo.Internal** TopicInfos;
            internal uint NumTopicInfos;
            internal uint FirstFileOffset;
            internal BSFixedString FormEditorID;
        }

        static TESTopic()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_TESTopic", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_TESTopic", 0));
            _vtables.Add("TESTopic", VTABLES.Get("VTABLE_TESTopic", 0));
            _vtables.Add("TESFullName", VTABLES.Get("VTABLE_TESTopic", 1));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator TESTopic(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(TESTopic instance) => (Internal*)instance.Native.ToPointer();

        public static TESTopic FromNative(nint ptr) => new((Internal*)ptr);

        public BGSDialogueBranch.Internal* OwnerBranch => ((Internal*)Native.ToPointer())->OwnerBranch;

        public TESQuest.Internal* OwnerQuest => ((Internal*)Native.ToPointer())->OwnerQuest;

        public TESTopicInfo.Internal** TopicInfos => ((Internal*)Native.ToPointer())->TopicInfos;

        public uint NumTopicInfos => ((Internal*)Native.ToPointer())->NumTopicInfos;

        public DIALOGUE_DATA.Subtype TopicSubtype => (DIALOGUE_DATA.Subtype)((Internal*)Native.ToPointer())->Data.SubtypeValue;
    }

    public static unsafe class TESTopicExt
    {
        public static nint GetFormEditorID<T>(this T topic) where T : ITESTopic, IFromNative
            => topic.Native.CallVirt<nint>(0x32, topic.Vtables["TESTopic"]);

        public static bool SetFormEditorID<T>(this T topic, nint a_str) where T : ITESTopic, IFromNative
            => topic.Native.CallVirt<nint, bool>(a_str, 0x33, topic.Vtables["TESTopic"]);

        public static uint GetFullNameLength<T>(this T topic) where T : ITESTopic, IFromNative
            => topic.Native.CallVirt<uint>(0x04, topic.Vtables["TESFullName"]);

        public static nint GetFullName<T>(this T topic) where T : ITESTopic, IFromNative
            => topic.Native.CallVirt<nint>(0x05, topic.Vtables["TESFullName"]);
    }

    public unsafe interface ITESTopic : ITESForm, ITESFullName;
}
