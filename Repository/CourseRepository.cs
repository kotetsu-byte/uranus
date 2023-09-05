using Uranus.Data;
using Uranus.Exceptions;
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
            try
            {
                return _context.Courses.Where(c => c.Id == id).First();
            } catch(Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public Course GetCourseByName(string name)
        {
            try
            {
                return _context.Courses.Where(c => c.Name == name).First();
            } catch(Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public bool CourseExists(int id)
        {
            return _context.Courses.Any(c => c.Id == id);
        }

        public ICollection<Test> GetTests(int id)
        {
            try
            {
                var course = _context.Courses.Where(c => c.Id == id).First();

                return course.Tests;
            }
            catch (Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public bool CreateCourse(Course course)
        {
            if (CourseExists(course.Id))
                throw new NotFoundException();

            _context.Courses.Add(course);

            return Save();
        }

        public bool UpdateCourse(Course course)
        {
            if (!CourseExists(course.Id))
                throw new NotFoundException();

            _context.Courses.Update(course);

            return Save();
        }

        public bool DeleteCourse(Course course)
        {
            if (!CourseExists(course.Id))
                throw new NotFoundException();

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
