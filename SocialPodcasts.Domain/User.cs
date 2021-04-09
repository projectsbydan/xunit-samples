using System.Collections.Generic;

namespace SocialPodcasts.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        // public IEnumerable<Podcast> SubscribedPodcasts { get; set; }
        
        // public IEnumerable<Podcast> OwnPodcasts { get; set; }
    }
}
