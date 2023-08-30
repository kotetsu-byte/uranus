using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IHomeworkRepository
    {
        public ICollection<Homework> GetHomeworks();
        public Homework GetHomeworkById(int id);
        public Homework GetHomeworkByTitle(string title);
        public bool HomeworkExists(int id);
        public string[] GetMaterials(int id);
        public bool CreateHomework(Homework homework);
        public bool UpdateHomework(Homework homework);
        public bool DeleteHomework(Homework homework);
        public bool Save();
    }
}
