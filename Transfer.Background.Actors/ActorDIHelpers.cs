using Akka.Actor;
using Akka.DI.Core;

namespace Transfer.Background.Actors
{
    public static class ActorDIHelpers
    {
        public static IActorRef ActorOfDI<T> (this ActorSystem actorSystem, string name = null) where T : ActorBase
        {
            return actorSystem.ActorOf(actorSystem.DI().Props<T>(), name);
        }

        public static IActorRef ActorOfDI<T>(this IActorContext actorContext, string name = null) where T : ActorBase
        {
            return actorContext.ActorOf(actorContext.DI().Props<T>(), name);
        }

    }
}
