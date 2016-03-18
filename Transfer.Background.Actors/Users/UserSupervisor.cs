using Akka.Actor;
using Akka.Event;
using Transfer.Background.Interfaces.Users;
using Transfer.PublicMessages.Users;

namespace Transfer.Background.Actors.Users
{
    public class UserSupervisor : ReceiveActor
    {
        public UserSupervisor()
        {
            _log = Logging.GetLogger(Context);
            _log.Warning("UserSupervisor started at '{0}'", Self.Path);

            _finder = Context.ActorOfDI<UserFinder>("Finder");

            Receive<LoadUserRequest>(rq => OnLoadUserRequest(rq));
            Receive<UserProfile>(rq => OnLoadUserProfile(rq));
        }

        private void OnLoadUserRequest(LoadUserRequest rq)
        {
            var userActor = Context.Child(rq.ExternalUserId);

            if (userActor == ActorRefs.Nobody)
            {
                // Need to try a bit harder!
                _finder.Tell(rq, this.Sender);
            }
            else
            {
                Sender.Tell(new LoadUserResponse(true, userActor));
            }
        }

        private void OnLoadUserProfile(UserProfile rq)
        {
            // Create the child actor and give it the loaded profile
            var child = Context.ActorOfDI<User>(rq.ExternalUserId);
            child.Tell(rq, Context.Self);

            // And then tell the original Sender that we've loaded the iser
            Sender.Tell(new LoadUserResponse(true, child));
        }

        private readonly IActorRef _finder;
        private readonly ILoggingAdapter _log;
    }
}
