namespace Transfer.Background.Interfaces.Users
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }

        public string ExternalUserId { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public static UserProfile None = new UserProfile();
    }
}
