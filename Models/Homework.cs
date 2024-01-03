using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uranus.Models
{
    public class Homework
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<Material>? Materials { get; set; }
        public DateOnly? Deadline { get; set; }
        public bool? IsDone { get; set; } = false;
        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }
        public Lesson? Lesson { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
