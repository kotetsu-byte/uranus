using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface ILessonRepository
    {
        public Task<ICollection<Lesson>> GetAllLessons(int courseId);
        public Task<Lesson> GetLessonById(int courseId, int id);
        public bool Exists(int id);
        public bool Exists(int courseId, int id);
        public bool Create(Lesson lesson);
        public bool Update(Lesson lesson);
        public bool Delete(int id);
        public bool Save();
    }
}
