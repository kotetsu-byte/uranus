using Uranus.Data;
using Uranus.Exceptions;
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
            try
            {
                return _context.Lessons.Where(l => l.Id == id).First();
            } catch(Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public bool LessonExists(int id)
        {
            return _context.Lessons.Any(l => l.Id == id);
        }

        public string[] GetVideos(int id)
        {
            var lesson = _context.Lessons.Where(c => c.Id == id).First();

            try
            {
                return lesson.Videos;
            } catch(Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public string[] GetDocs(int id)
        {
            var lesson = _context.Lessons.Where(c => c.Id == id).First();

            try
            {
                return lesson.Docs;
            } catch(Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public bool CreateLesson(Lesson lesson)
        {
            if (!LessonExists(lesson.Id))
                throw new NotFoundException();
            
            _context.Lessons.Add(lesson);

            return Save();
        }

        public bool UpdateLesson(Lesson lesson)
        {
            if (!LessonExists(lesson.Id))
                throw new NotFoundException();

            _context.Update(lesson);

            return Save();
        }

        public bool DeleteLesson(Lesson lesson)
        {
            if (!LessonExists(lesson.Id))
                throw new NotFoundException();

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
