namespace Uranus.Models
{
    public class Homework
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Material> Materials { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }
        public Lesson Lesson { get; set; }
    }
}
