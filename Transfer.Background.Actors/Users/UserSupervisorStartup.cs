using Akka.Actor;
using Transfer.Background.Interfaces;

namespace Transfer.Background.Actors.Users
{
    public class UserSupervisorStartup : IStartup
    {
        public UserSupervisorStartup(ActorSystem actorSystem)
        {
            _actorSystem = actorSystem;
        }

        public void Start()
        {
            _actorSystem.ActorOfDI<UserSupervisor>("UserSupervisor");
        }

        private readonly ActorSystem _actorSystem;
    }
}
