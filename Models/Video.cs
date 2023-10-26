namespace Uranus.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Lesson Lesson { get; set; }
    }
}
