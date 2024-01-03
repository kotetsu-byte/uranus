using Microsoft.EntityFrameworkCore;
using Uranus.Data;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class DocRepository : IDocRepository
    {
        private readonly DataContext _context;

        public DocRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Doc>> GetAllDocs(int courseId, int lessonId)
        {
            return await _context.Docs.Where(d => d.CourseId == courseId && d.LessonId == lessonId).OrderBy(d => d.Id).ToListAsync();
        }

        public async Task<Doc> GetDocById(int courseId, int lessonId, int id)
        {
            return await _context.Docs.Where(d => d.CourseId == courseId && d.LessonId == lessonId && d.Id == id).FirstOrDefaultAsync();
        }

        public bool Exists(int id)
        {
            return _context.Docs.Any(d => d.Id == id);
        }

        public bool Exists(int courseId, int lessonId, int id)
        {
            return _context.Docs.Any(d => d.CourseId == courseId && d.LessonId == lessonId && d.Id == id);
        }

        public bool Create(Doc doc)
        {
            _context.Docs.Add(doc);

            return Save();
        }

        public bool Update(Doc doc)
        {
            _context.Docs.Update(doc);

            return Save();
        }

        public bool Delete(int id)
        {
            var doc = _context.Docs.Where(d => d.Id == id).FirstOrDefault();
            
            _context.Docs.Remove(doc);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
