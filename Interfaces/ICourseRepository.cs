using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface ICourseRepository
    {
        public ICollection<Course> GetCourses();
        public Course GetCourseById(int id);
        public Course GetCourseByName(string courseName);
        public bool CourseExists(int id);
        public string[] GetTests(int id);
        public bool CreateCourse(Course course, string name, string description, double price, string[] tests);
        public bool UpdateCourse(Course course);
        public bool DeleteCourse(Course course);
        public bool Save();
    }
}
