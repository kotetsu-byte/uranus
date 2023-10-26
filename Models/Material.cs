namespace Uranus.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public Homework Homework { get; set; }
    }
}
