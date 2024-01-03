using Microsoft.EntityFrameworkCore;
using Uranus.Data;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Course>> GetAllCourses()
        {
            return await _context.Courses.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _context.Courses.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public bool Exists(int id)
        {
            return _context.Courses.Any(c => c.Id == id);
        }

        public bool Create(Course course)
        {
            _context.Courses.Add(course);

            return Save();
        }

        public bool Update(Course course)
        {
            _context.Courses.Update(course);

            return Save();
        }

        public bool Delete(int id)
        {
            var course = _context.Courses.Where(c => c.Id == id).FirstOrDefault();
            
            _context.Courses.Remove(course);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
