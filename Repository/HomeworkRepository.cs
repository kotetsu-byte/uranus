using Microsoft.EntityFrameworkCore;
using Uranus.Data;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly DataContext _context;

        public HomeworkRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Homework>> GetAllHomeworks(int courseId, int lessonId)
        {
            return await _context.Homeworks.Where(h => h.CourseId == courseId && h.LessonId == lessonId).OrderBy(h => h.Id).ToListAsync();
        }

        public async Task<Homework> GetHomeworkById(int courseId, int lessonId, int id)
        {
            return await _context.Homeworks.Where(h => h.CourseId == courseId && h.LessonId == lessonId && h.Id == id).FirstOrDefaultAsync();
        }

        public bool Exists(int id)
        {
            return _context.Homeworks.Any(h => h.Id == id);
        }

        public bool Exists(int courseId, int lessonId, int id)
        {
            return _context.Homeworks.Any(h => h.CourseId == courseId && h.LessonId == lessonId && h.Id == id);
        }

        public bool Create(Homework homework)
        {
            _context.Homeworks.Add(homework);

            return Save();
        }

        public bool Update(Homework homework)
        {
            _context.Homeworks.Update(homework);

            return Save();
        }

        public bool Delete(int id)
        {
            var homework = _context.Homeworks.Where(h => h.Id == id).FirstOrDefault();
            
            _context.Homeworks.Remove(homework);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
