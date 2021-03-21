using SocialPodcasts.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialPodcasts.BLL.Tests.Services
{
    public class UserServiceTests
    {
        private UserService _userService;

        public UserServiceTests()
        {
            _userService = new UserService();
        }

        [Fact]
        public void ShouldHaveFullName()
        {
            // arrange
            var firstName = "Jimmy";
            var lastName = "Jones";

            // act
            var user = _userService.AddUser(firstName, lastName);

            // assert
            Assert.Equal("Jimmy Jones", user.FullName);

        }
    }
}
