using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IHomeworkRepository
    {
        public Task<ICollection<Homework>> GetAllHomeworks(int courseId, int lessonId);
        public Task<Homework> GetHomeworkById(int courseId, int lessonId, int id);
        public bool Exists(int id);
        public bool Exists(int courseId, int lessonId, int id);
        public bool Create(Homework homework);
        public bool Update(Homework homework);
        public bool Delete(int id);
        public bool Save();
    }
}
