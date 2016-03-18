using Akka.Actor;

namespace Transfer.PublicMessages.Users
{
    /// <summary>
    /// Returned from a LoadUserRequest
    /// </summary>
    public class LoadUserResponse
    {
        /// <summary>
        /// Create the response
        /// </summary>
        /// <param name="found"></param>
        /// <param name="userReference"></param>
        public LoadUserResponse(bool found, IActorRef userReference)
        {
            this.Found = found;
            this.UserReference = userReference;
        }

        /// <summary>
        /// True if the user actor was found
        /// </summary>
        public bool Found { get; private set; }

        /// <summary>
        /// If the user actor was found, this provides the reference to the actor
        /// </summary>
        public IActorRef UserReference { get; private set; }
    }
}
