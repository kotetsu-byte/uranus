namespace Uranus.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public string[] Videos { get; set; }
        public string[] Docs { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
        public Course Course { get; set; }
    }
}
