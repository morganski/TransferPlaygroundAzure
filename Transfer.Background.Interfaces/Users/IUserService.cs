namespace Transfer.Background.Interfaces.Users
{
    public interface IUserService
    {
        UserProfile GetUserProfile(string externalUserId);

        UserProfile CreateUserProfile(string externalUserId, string forename, string surname, string emailAddress);
    }
}
