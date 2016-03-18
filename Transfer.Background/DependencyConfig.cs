using Akka.Actor;
using Akka.DI.AutoFac;
using Autofac;
using System;
using Transfer.Background.Modules;

namespace Transfer.Background
{
    public class DependencyConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            var lazyContainer = new Lazy<IContainer>(() => builder.Build());

            builder.Register(cc =>
            {
                var system = ActorSystem.Create("TransferServer");
                new AutoFacDependencyResolver(lazyContainer.Value, system);

                return system;
            }).SingleInstance();

            builder.RegisterType<Bootstrapper>().AsSelf();

            builder.RegisterModule<ActorsModule>();
            builder.RegisterModule<ServicesModule>();

            return lazyContainer.Value;
        }
    }
}
