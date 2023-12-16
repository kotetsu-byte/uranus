namespace Uranus.Dto
{
    public class HomeworkDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? Deadline { get; set; }
        public bool? IsDone { get; set; }
        public int? LessonId { get; set; }
        public int? CourseId { get; set; }
    }
}
