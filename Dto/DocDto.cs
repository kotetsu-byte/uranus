using System.ComponentModel.DataAnnotations;

namespace Uranus.Dto
{
    public class DocDto
    {
        public required int? Id { get; set; }
        public required string? Title { get; set; }
        public required string? Url { get; set; }
        public required int? LessonId { get; set; }
        public required int? CourseId { get; set; }
    }
}
