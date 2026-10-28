using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSScene(BGSScene.Internal* ptr)
        : IBGSScene, IFromNative<BGSScene, BGSScene.Internal>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal TESForm.Internal Base_0;

            internal BSTArray<Ptr<BGSScenePhase>>.Internal Phases;
            internal BSTArray<uint>.Internal Actors;
            internal BSTArray<uint>.Internal ActorFlags;
            internal BSTArray<uint>.Internal ActorProgressionFlags;
            internal BSTArray<Ptr<BGSSceneAction.Internal>>.Internal Actions;
            internal TESQuest.Internal* ParentQuest;
            internal uint Flags;
            internal uint padA4;
            internal TESCondition Conditions;
            internal bool IsPlaying;
            internal byte unkB1;
            internal byte unkB2;
            internal byte unkB3;
            internal uint unkB4;
            internal uint unkB8;
            internal uint unkBC;
            internal uint unkC0;
            internal uint padC4;
        }

        static BGSScene()
        {
            _vtables.Add("BaseFormComponent", VTABLES.Get("VTABLE_BGSScene", 0));
            _vtables.Add("TESForm", VTABLES.Get("VTABLE_BGSScene", 0));
            _vtables.Add("BGSScene", VTABLES.Get("VTABLE_BGSScene", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator BGSScene(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BGSScene instance) => (Internal*)instance.Native.ToPointer();

        public static BGSScene FromNative(nint ptr) => new((Internal*)ptr);

        public TESQuest.Internal* ParentQuest => ((Internal*)Native.ToPointer())->ParentQuest;

        public bool IsPlaying
        {
            get => ((Internal*)Native.ToPointer())->IsPlaying;
            set => ((Internal*)Native.ToPointer())->IsPlaying = value;
        }

        public bool BeginOnQuestStart => ((((Internal*)Native.ToPointer())->Flags >> 0) & 1) != 0;

        public bool StopOnQuestEnd => ((((Internal*)Native.ToPointer())->Flags >> 1) & 1) != 0;

        public bool Interruptible => ((((Internal*)Native.ToPointer())->Flags >> 4) & 1) != 0;
    }

    public static unsafe class BGSSceneExt
    {
        public static bool BeginOnQuestStart<T>(this T scene) where T : IBGSScene, IFromNative
            => ((((BGSScene.Internal*)scene.Native)->Flags >> 0) & 1) != 0;

        public static bool StopOnQuestEnd<T>(this T scene) where T : IBGSScene, IFromNative
            => ((((BGSScene.Internal*)scene.Native)->Flags >> 1) & 1) != 0;

        public static bool Interruptible<T>(this T scene) where T : IBGSScene, IFromNative
            => ((((BGSScene.Internal*)scene.Native)->Flags >> 4) & 1) != 0;
    }

    public unsafe interface IBGSScene : ITESForm;
}
