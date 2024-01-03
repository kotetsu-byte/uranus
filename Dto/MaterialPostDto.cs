namespace Uranus.Dto
{
    public class MaterialPostDto
    {
        public required string? Title { get; set; }
        public required string? Url { get; set; }
        public required int? HomeworkId { get; set; }
        public required int? LessonId { get; set; }
        public required int? CourseId { get; set; }
    }
}
