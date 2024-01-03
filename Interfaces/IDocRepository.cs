using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IDocRepository
    {
        public Task<ICollection<Doc>> GetAllDocs(int courseId, int lessonId);
        public Task<Doc> GetDocById(int courseId, int lessonId, int id);
        public bool Exists(int id);
        public bool Exists(int courseId, int lessonId, int id);
        public bool Create(Doc doc);
        public bool Update(Doc doc);
        public bool Delete(int id);
        public bool Save();
    }
}
