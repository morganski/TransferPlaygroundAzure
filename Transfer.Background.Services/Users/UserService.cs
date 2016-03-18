using System.Collections.Generic;
using Transfer.Background.Interfaces.Users;

namespace Transfer.Background.Services.Users
{
    public class UserService : IUserService
    {
        public UserService()
        {
            _profiles = new Dictionary<string, UserProfile>();
            _profiles.Add("testing@vitessepsp.com", new UserProfile { UserProfileId = _id++, ExternalUserId = "testing@vitessepsp.com", Forename = "Testy", Surname = "McTester", EmailAddress = "testing@vitessepsp.com" });
        }

        public UserProfile CreateUserProfile(string externalUserId, string forename, string surname, string emailAddress)
        {
            var profile = this.GetUserProfile(externalUserId);

            if (profile == UserProfile.None)
            {
                profile = new UserProfile { UserProfileId = _id++, ExternalUserId = externalUserId, Forename = forename, Surname = surname, EmailAddress = emailAddress };
                _profiles.Add(externalUserId, profile);
            }

            return profile;
        }

        public UserProfile GetUserProfile(string externalUserId)
        {
            UserProfile profile = null;

            if (!_profiles.TryGetValue(externalUserId, out profile))
                profile = UserProfile.None;

            return profile;
        }

        private Dictionary<string, UserProfile> _profiles;
        private int _id = 0;
    }
}
