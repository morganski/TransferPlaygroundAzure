using Akka.Actor;
using Autofac;
using System.Linq;
using Transfer.Background.Actors.Users;
using Transfer.Background.Interfaces;

namespace Transfer.Background.Modules
{
    public class ActorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assem = typeof(UserSupervisor).Assembly;

            builder.RegisterAssemblyTypes(assem)
                .Where(t => t.IsAssignableTo<ReceiveActor>())
                .AsSelf();

            builder.RegisterAssemblyTypes(assem)
                .Where(t => t.IsAssignableTo<IStartup>())
                .As<IStartup>();
        }
    }
}
