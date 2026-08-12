using SkyrimSharpLoader.Internal.Interfaces;

namespace SkyrimSharpLoader.Compat.Prisma.Abstracts
{
    public abstract class RegisterView : IRegister<PrismaView>
    {
        public abstract PrismaView Register();
    }
}
