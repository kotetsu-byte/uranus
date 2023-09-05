namespace Uranus.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Doc> Docs { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
        public Course Course { get; set; }
    }
}
