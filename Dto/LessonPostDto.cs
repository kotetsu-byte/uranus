namespace Uranus.Dto
{
    public class LessonPostDto
    {
        public required string? Title { get; set; }
        public required string? Info { get; set; }
        public required int? CourseId { get; set; }
    }
}
