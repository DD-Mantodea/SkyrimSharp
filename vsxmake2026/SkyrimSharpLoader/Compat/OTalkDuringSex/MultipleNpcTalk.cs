using SkyrimSharpLoader.Compat.Prisma;
using SkyrimSharpLoader.Compat.Prisma.Abstracts;
using SkyrimSharpLoader.Internal;
using SkyrimSharpLoader.Interop.NativeStructures;
using SkyrimSharpLoader.Interop.RE;

namespace SkyrimSharpLoader.Compat.OTalkDuringSex
{
    public class MultipleNpcTalk : RegisterView
    {
        public static ClickItemChannel ClickItemChannel = new();

        public static PrismaView Instance;

        public override PrismaView Register()
        {
            Instance = Prisma.Prisma.CreateView($"OTalkDuringSex/{nameof(MultipleNpcTalk)}.html");

            Instance.Hide();

            Instance.RegisterJSListener("clickItem", (data) =>
            {
                Logger.Debug($"{nameof(MultipleNpcTalk)} click item: {data}");

                if (nint.TryParse(data, out var ptr))
                    ClickItemChannel.Send(new(ptr));
                else
                    Logger.Error($"{nameof(MultipleNpcTalk)} error: clickItem index is not a number {data}");

                Instance.Unfocus();

                Instance.Hide();
            });

            ClickItemChannel.Register(OnClickItem);

            return Instance;
        }

        public unsafe static ClickItemChannel.EventHandler OnClickItem = (eventName, args) =>
        {
            var actor = new Actor(args.Ptr);

            actor.ActivateRef(PlayerCharacter.Singleton, 0, actor.GetBaseObject(), 1);
        };
    }

    public record struct ClickItemArgs(Ptr<Actor.Internal> Ptr);

    public class ClickItemChannel : EventChannel<ClickItemArgs, ClickItemArgs>;
}
