using System.ComponentModel.DataAnnotations;

namespace Uranus.Dto
{
    public class DocDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public int? LessonId { get; set; }
        public int? CourseId { get; set; }
    }
}
