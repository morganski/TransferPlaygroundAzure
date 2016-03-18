using Akka.Actor;
using Transfer.Background.Interfaces.Users;

namespace Transfer.Background.Actors.Users
{
    public class User : ReceiveActor
    {
        public User()
        {
            Receive<UserProfile>(rq => this.Profile = rq);
        }

        public UserProfile Profile { get; set; }
    }
}
