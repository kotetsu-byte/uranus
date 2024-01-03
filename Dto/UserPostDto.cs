namespace Uranus.Dto
{
    public class UserPostDto
    {
        public required string? Name { get; set; }
        public required string? Email { get; set; }
        public required string? Username { get; set; }
        public required string? Password { get; set; }
        public required string? ConfirmPassword { get; set; }
    }
}
