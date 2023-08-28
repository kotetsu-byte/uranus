using Uranus.Data;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly DataContext _context;

        public LessonRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Lesson> GetLessons()
        {
            return _context.Lessons.OrderBy(x => x.Id).ToList();
        }

        public Lesson GetLessonById(int id)
        {
            return _context.Lessons.Where(l => l.Id == id).FirstOrDefault();
        }

        public bool LessonExists(int id)
        {
            return _context.Lessons.Any(l => l.Id == id);
        }

        public string[] GetVideos(int id)
        {
            var lesson = _context.Lessons.Where(c => c.Id == id).FirstOrDefault();

            return lesson.Videos;
        }

        public string[] GetDocs(int id)
        {
            var lesson = _context.Lessons.Where(c => c.Id == id).FirstOrDefault();

            return lesson.Docs;
        }

        public bool CreateLesson(Lesson lesson, int courseId, string info, string[] videos, string[] docs)
        {

            lesson.Info = info;
            lesson.Videos = videos;
            lesson.Docs = docs;
            lesson.Course.Id = courseId;

            _context.Lessons.Add(lesson);

            return Save();
        }

        public bool UpdateLesson(Lesson lesson)
        {
            _context.Update(lesson);

            return Save();
        }

        public bool DeleteLesson(Lesson lesson)
        {
            _context.Remove(lesson);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
