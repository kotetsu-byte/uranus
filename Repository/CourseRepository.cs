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

        public ICollection<Course> GetCourses()
        {
            return _context.Courses.OrderBy(c => c.Id).ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Where(c => c.Id == id).FirstOrDefault();
        }

        public Course GetCourseByName(string name)
        {
            return _context.Courses.Where(c => c.Name == name).FirstOrDefault();
        }

        public bool CourseExists(int id) 
        {
            return _context.Courses.Any(c => c.Id == id);
        }

        public string[] GetTests(int id)
        {
            var course = _context.Courses.Where(c => c.Id == id).FirstOrDefault();

            return course.Tests;
        }

        public bool CreateCourse(Course course, string name, string description, double price, string[] tests)
        {
            course.Name = name;
            course.Description = description;
            course.Price = price;
            course.Tests = tests;

            _context.Add(course);

            return Save();
        }

        public bool UpdateCourse(Course course)
        {
            _context.Update(course);

            return Save();
        }

        public bool DeleteCourse(Course course) 
        {
            _context.Remove(course);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
