using SkyrimSharpLoader.Interop.Extensions;
using SkyrimSharpLoader.Interop.Interfaces;
using SkyrimSharpLoader.Interop.NativeStructures;
using System.Runtime.InteropServices;

namespace SkyrimSharpLoader.Interop.RE
{
    public unsafe readonly struct BGSSceneAction(BGSSceneAction.Internal* ptr)
        : IBGSSceneAction, IFromNative<BGSSceneAction, BGSSceneAction.Internal>
    {
        public enum Type
        {
            kDialogue = 0,
            kPackage = 1,
            kTimer = 2
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Internal
        {
            internal void** Vtable;
            internal uint ActorID;
            internal ushort StartPhase;
            internal ushort EndPhase;
            internal uint Flags;
            internal byte unk14;
            internal byte unk15;
            internal ushort unk16;
            internal uint Index;
            internal uint unk1C;
        }

        static BGSSceneAction()
        {
            _vtables.Add("BGSSceneAction", VTABLES.Get("VTABLE_BGSSceneAction", 0));
        }

        private static Dictionary<string, Vtable> _vtables = [];

        public Dictionary<string, Vtable> Vtables => _vtables;

        public nint Native { get; } = new(ptr);

        public static implicit operator BGSSceneAction(Internal* ptr) => new(ptr);

        public static implicit operator Internal*(BGSSceneAction instance) => (Internal*)instance.Native.ToPointer();

        public static BGSSceneAction FromNative(nint ptr) => new((Internal*)ptr);

        public uint ActorID => ((Internal*)Native.ToPointer())->ActorID;

        public uint Index => ((Internal*)Native.ToPointer())->Index;
    }

    public static unsafe class BGSSceneActionExt
    {
        public static BGSSceneAction.Type GetType<T>(this T action) where T : IBGSSceneAction, IFromNative
            => (BGSSceneAction.Type)action.Native.CallVirt<uint>(0x07, action.Vtables["BGSSceneAction"]);

        public static bool Loops<T>(this T action) where T : IBGSSceneAction, IFromNative
            => action.Native.CallVirt<bool>(0x05, action.Vtables["BGSSceneAction"]);

        public static bool FacesTarget<T>(this T action) where T : IBGSSceneAction, IFromNative
            => action.Native.CallVirt<bool>(0x06, action.Vtables["BGSSceneAction"]);

        public static void ClearFlags<T>(this T action) where T : IBGSSceneAction, IFromNative
            => action.Native.CallVoidVirt(0x04, action.Vtables["BGSSceneAction"]);
    }

    public unsafe interface IBGSSceneAction : IFromNative, IHaveVtable;
}
