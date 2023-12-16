using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<Lesson>> GetAllLessons(int courseId)
        {
            return await _context.Lessons.Where(l => l.CourseId == courseId).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Lesson> GetLessonById(int courseId, int id)
        {
            return await _context.Lessons.Where(l => l.CourseId == courseId && l.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Lesson lesson)
        {
            _context.Lessons.Add(lesson);

            return Save();
        }

        public bool Update(Lesson lesson)
        {
            _context.Lessons.Update(lesson);

            return Save();
        }

        public bool Delete(int id)
        {
            var lesson = _context.Lessons.Where(l => l.Id == id).FirstOrDefault();
            
            _context.Lessons.Remove(lesson);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
