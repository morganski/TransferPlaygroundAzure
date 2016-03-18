using Akka.Actor;
using Akka.Event;
using Transfer.Background.Interfaces.Users;
using Transfer.PublicMessages.Users;

namespace Transfer.Background.Actors.Users
{
    public class UserFinder : ReceiveActor
    {
        public UserFinder(IUserService userService)
        {
            _log = Logging.GetLogger(Context);
            _log.Warning("UserFinder started at '{0}'", Self.Path);
            _userService = userService;

            Receive<LoadUserRequest>(rq => OnLoadUser(rq));
        }

        private void OnLoadUser(LoadUserRequest rq)
        {
            var profile = _userService.CreateUserProfile(rq.ExternalUserId, rq.Forename, rq.Surname, rq.EmailAddress);

            Context.Parent.Tell(profile, this.Sender);
        }

        private readonly IUserService _userService;
        private readonly ILoggingAdapter _log;
    }
}
