using AutoFixture;
using AutoFixture.Xunit2;
using SocialPodcasts.BLL.Services;
using SocialPodcasts.Domain;
using System.Linq;
using Xunit;

namespace SocialPodcasts.BLL.Tests.Services
{
    public class PodcastServiceShould
    {
        private PodcastService _sut;


        public PodcastServiceShould()
        {
            var fixture = new Fixture();

            var data = fixture.CreateMany<Podcast>(10).ToList();

            _sut = new PodcastService(data);
        }

        [Fact]
        public void HaveTenPodcasts()
        {
            // arrange
            // sut already done in constructor

            // act
            var podcasts = _sut.GetPodcasts();
            var count = podcasts.Count();

            // assert
            Assert.NotEmpty(podcasts);
            Assert.Equal(10, count);
        }

        [Fact]
        public void AddSpecificPodcast()
        {
            // arrange
            // sut already done in constructor
            var id = 1;
            var name = "Name 1"; // magic strings are bad
            var ownerId = 3;

            // act
            var podcasts = _sut.AddPodcast(id, name, ownerId);

            // assert
            Assert.Contains(podcasts, x => x.Id == id && x.Name == name && x.Owner.Id == ownerId);
        }

        [Theory]
        [InlineData(1, "name 1", 1)]
        [InlineData(2, "name 2", 1)]
        [InlineData(3, "name 3", 1)]
        public void AddPodcasts(int id, string name, int ownerId)
        {
            // arrange
            // sut already done in constructor
            // data from inline data

            // act
            var podcasts = _sut.AddPodcast(id, name, ownerId);

            // assert
            Assert.Contains(podcasts, x => x.Id == id && x.Name == name && x.Owner.Id == ownerId);
        }

        [Fact]
        public void AddPodcast()
        {
            // arrange
            // sut already done in constructor
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            var name = fixture.Create<string>();
            var ownerId = fixture.Create<int>();

            // act
            var podcasts = _sut.AddPodcast(id, name, ownerId);

            // assert
            Assert.Contains(podcasts, x => x.Id == id && x.Name == name && x.Owner.Id == ownerId);
        }

        [Theory]
        [AutoData]
        public void AddFixturePodcast(int id, string name, int ownerId)
        {
            // arrange
            // sut already done in constructor
            // data from auto data

            // act
            var podcasts = _sut.AddPodcast(id, name, ownerId);

            // assert
            Assert.Contains(podcasts, x => x.Id == id && x.Name == name && x.Owner.Id == ownerId);
        }

    }
}
