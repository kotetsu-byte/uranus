namespace Uranus.Dto
{
    public class TestPostDto
    {
        public required string? Question { get; set; }
        public required string? Answer1 { get; set; }
        public required string? Answer2 { get; set; }
        public required string? Answer3 { get; set; }
        public required string? Answer4 { get; set; }
        public required int? CorrectAnswer { get; set; }
        public required int? Points { get; set; }
        public required int? CourseId { get; set; }
    }
}
