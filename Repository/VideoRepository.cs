using Uranus.Data;
using Uranus.Exceptions;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DataContext _context;

        public VideoRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Video> GetVideos()
        {
            return _context.Videos.OrderBy(v => v.Id).ToList();
        }

        public Video GetVideoById(int id) 
        { 
            try
            {
                return _context.Videos.Where(v => v.Id == id).First();
            } catch(Exception ex) 
            {
                throw new NotFoundException();
            }
        }

        public bool VideoExists(int id)
        {
            return _context.Videos.Any(v => v.Id == id);
        }

        public bool CreateVideo(Video video)
        {
            if (VideoExists(video.Id))
                throw new NotFoundException();

            _context.Videos.Add(video);

            return Save();
        }

        public bool UpdateVideo(Video video)
        {
            if (!VideoExists(video.Id))
                throw new NotFoundException();

            _context.Videos.Update(video);

            return Save();
        }

        public bool DeleteVideo(Video video)
        {
            if (!VideoExists(video.Id))
                throw new NotFoundException();

            _context.Videos.Remove(video);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
