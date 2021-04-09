using AutoFixture;
using SocialPodcasts.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialPodcasts.BLL.Tests.Services
{
    public class UserServiceShould
    {
        private UserService _sut; // system under test, convention name

        public UserServiceShould()
        {
            _sut = new UserService();
        }

        [Fact]
        public void AddUserWithFullName()
        {
            // arrange
            var firstName = "Jimmy"; // magic strings, don't do this
            var lastName = "Jones"; // magic strings, don't do this

            // act
            var user = _sut.AddUser(firstName, lastName);

            // assert
            Assert.Equal("Jimmy Jones", user.FullName);
        }

        [Fact]
        public void HaveFullNameWithSpace()
        {
            // arrange
            var firstName = "Jack"; // magic strings, don't do this
            var lastName = "Smith"; // magic strings, don't do this

            // act
            var user = _sut.AddUser(firstName, lastName);

            // assert
            Assert.Matches(@"\w\s\w", user.FullName);
        }

        // Data driven example
        [Theory]
        [InlineData("Jimmy", "Jones")] // hard coding the values is not optimal
        [InlineData("Jack", "Smith")]
        [InlineData("Jenny","Tonies")]
        public void ContainFirstName(string firstName, string lastName)
        {
            // act
            var user = _sut.AddUser(firstName, lastName);

            // assert
            Assert.Contains(firstName, user.FullName);
        }


        // auto fixture data driven examples
        [Fact]
        public void StartWithFirstName()
        {
            // arrange
            var fixture = new Fixture();
            var firstName = fixture.Create<string>();
            var lastname = fixture.Create<string>();

            // act
            var user = _sut.AddUser(firstName, lastname);

            // assert
            Assert.StartsWith(firstName, user.FullName);
        }
    }
}
