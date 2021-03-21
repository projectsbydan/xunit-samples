using SocialPodcasts.Domain;

namespace SocialPodcasts.BLL.Services
{
    public class UserService
    {
        public User AddUser(string firstName, string lastName)
        {
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
            };


            // create user in the database

            return user;
        }

        public User SetUser(int id, string firstName, string lastName)
        {
            // get the user from the database by id
            var user = new User
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            return user;
        }
    }
}
