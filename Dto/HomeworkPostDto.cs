namespace Uranus.Dto
{
    public class HomeworkPostDto
    {
        public required string? Title { get; set; }
        public required string? Description { get; set; }
        public required DateOnly? Deadline { get; set; }
        public required bool? IsDone { get; set; }
        public required int? LessonId { get; set; }
        public required int? CourseId { get; set; }
    }
}
