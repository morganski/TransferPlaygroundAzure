using Autofac;
using Transfer.Background.Interfaces.Users;
using Transfer.Background.Services.Users;

namespace Transfer.Background.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assem = typeof(UserService).Assembly;

            builder.RegisterType<UserService>()
                .As<IUserService>();
        }
    }
}
