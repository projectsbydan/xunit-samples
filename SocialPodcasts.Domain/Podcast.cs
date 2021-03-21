namespace SocialPodcasts.Domain
{
    public class Podcast
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User Owner { get; set; }
    }
}
