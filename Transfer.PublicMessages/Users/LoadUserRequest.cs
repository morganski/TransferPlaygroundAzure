namespace Transfer.PublicMessages.Users
{
    /// <summary>
    /// Requests that a user is loaded
    /// </summary>
    public class LoadUserRequest
    {
        /// <summary>
        /// Create the message
        /// </summary>
        /// <param name="externalUserId"></param>
        /// <param name="forename"></param>
        /// <param name="surname"></param>
        /// <param name="emailAddress"></param>
        public LoadUserRequest(string externalUserId, string forename, string surname, string emailAddress)
        {
            this.ExternalUserId = externalUserId;
            this.Forename = forename;
            this.Surname = surname;
            this.EmailAddress = emailAddress;
        }

        /// <summary>
        /// The external ID used to uniquely identify the user
        /// </summary>
        public string ExternalUserId { get; private set; }

        /// <summary>
        /// The username forename
        /// </summary>
        public string Forename { get; private set; }

        /// <summary>
        /// The users surname
        /// </summary>
        public string Surname { get; private set; }

        /// <summary>
        /// The users email address
        /// </summary>
        public string EmailAddress { get; private set; }
    }
}
