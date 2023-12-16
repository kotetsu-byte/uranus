using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface ICourseRepository
    {
        public Task<ICollection<Course>> GetAllCourses();
        public Task<Course> GetCourseById(int id);
        public bool Create(Course course);
        public bool Update(Course course);
        public bool Delete(int id);
        public bool Save();
    }
}
