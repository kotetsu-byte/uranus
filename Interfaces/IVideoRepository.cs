using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IVideoRepository
    {
        public ICollection<Video> GetVideos();
        public Video GetVideoById(int id);
        public bool VideoExists(int id);
        public bool CreateVideo(Video video);
        public bool UpdateVideo(Video video);
        public bool DeleteVideo(Video video);
        public bool Save();
    }
}
