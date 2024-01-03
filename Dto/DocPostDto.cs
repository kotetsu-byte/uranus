namespace Uranus.Dto
{
    public class DocPostDto
    {
        public required string? Title { get; set; }
        public required string? Url { get; set; }
        public required int? LessonId { get; set; }
        public required int? CourseId { get; set; }
    }
}
