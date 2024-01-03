using Microsoft.EntityFrameworkCore;
using Uranus.Data;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext _context;

        public TestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Test>> GetAllTests(int courseId)
        {
            return await _context.Tests.Where(t => t.CourseId == courseId).OrderBy(t => t.Id).ToListAsync();
        }

        public async Task<Test> GetTestById(int courseId, int id)
        {
            return await _context.Tests.Where(t => t.CourseId == courseId && t.Id == id).FirstOrDefaultAsync();
        }

        public bool Exists(int id)
        {
            return _context.Tests.Any(t => t.Id == id);
        }

        public bool Exists(int courseId, int id)
        {
            return _context.Tests.Any(t => t.CourseId == courseId && t.Id == id);
        }

        public bool Create(Test test)
        {
            _context.Tests.Add(test);

            return Save();
        }

        public bool Update(Test test)
        {
            _context.Tests.Update(test);

            return Save();
        }

        public bool Delete(int id)
        {
            var test = _context.Tests.Where(t => t.Id == id).FirstOrDefault();
            
            _context.Tests.Remove(test);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
