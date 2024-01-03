namespace Uranus.Dto
{
    public class LessonDto
    {
        public required int? Id { get; set; }
        public required string? Title { get; set; }
        public required string? Info { get; set; }
        public required int? CourseId { get; set; }
    }
}
