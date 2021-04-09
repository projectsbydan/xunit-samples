using SocialPodcasts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPodcasts.BLL.Services
{
    public class PodcastService
    {
        private List<Podcast> _data;

        public PodcastService(List<Podcast> data)
        {
            _data = data;
        }

        public IEnumerable<Podcast> GetPodcasts()
        {
            return _data;
        }

        public IEnumerable<Podcast> AddPodcast(int id, string name, int ownerId)
        {
            if (_data.Any(x => x.Id == id))
            {
                throw new ArgumentException("A podcast with this id already exists!", nameof(id));
            }

            _data.Add(new Podcast { Id = id, Name = name, Owner = new User { Id = ownerId } });

            return _data;
        }

        public IEnumerable<Podcast> RemovePodcast(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new ArgumentException("A podcast with this id does not exist!", nameof(id));
            }

            _data.Remove(item);

            return _data;
        }
    }
}
