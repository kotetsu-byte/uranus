namespace Uranus.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string[] Tests { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
    }
}