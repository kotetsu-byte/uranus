namespace Uranus.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }
        public int Points { get; set; }
    }
}
