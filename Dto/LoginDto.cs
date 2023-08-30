namespace Uranus.Dto
{
    public class LoginDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
