using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IVideoRepository
    {
        public Task<ICollection<Video>> GetAllVideos(int courseId, int lessonId);
        public Task<Video> GetVideoById(int courseId, int lessonId, int id);
        public bool Create(Video video);
        public bool Update(Video video);
        public bool Delete(int id);
        public bool Save();
    }
}
