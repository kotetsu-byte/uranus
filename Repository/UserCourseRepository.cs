using Microsoft.EntityFrameworkCore;
using Uranus.Data;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly DataContext _context;

        public UserCourseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<UserCourse>> GetAllUserCourses()
        {
            return await _context.UserCourses.OrderBy(u => u.UserId).ToListAsync();
        }

        public async Task<UserCourse> GetUserCourseById(int userId, int courseId)
        {
            return await _context.UserCourses.Where(uc => uc.UserId == userId && uc.CourseId == courseId).FirstOrDefaultAsync();
        }

        public bool Exists(int userId, int courseId)
        {
            return _context.UserCourses.Any(uc => uc.UserId == userId && uc.CourseId == courseId);
        }

        public bool Create(UserCourse userCourse)
        {
            _context.UserCourses.Add(userCourse);

            return Save();
        }

        public bool Update(UserCourse userCourse)
        {
            _context.UserCourses.Update(userCourse);

            return Save();
        }

        public bool Delete(int userId, int courseId) 
        {
            var userCourse = _context.UserCourses.Where(uc => uc.UserId == userId && uc.CourseId == courseId).FirstOrDefault();
            
            _context.UserCourses.Remove(userCourse);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
