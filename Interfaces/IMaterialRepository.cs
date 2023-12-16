using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IMaterialRepository
    {
        public Task<ICollection<Material>> GetAllMaterials(int courseId, int lessonId, int homeworkId);
        public Task<Material> GetMaterialById(int courseId, int lessonId, int homeworkId, int id);
        public bool Create(Material material);
        public bool Update(Material material);
        public bool Delete(int id);
        public bool Save();
    }
}
