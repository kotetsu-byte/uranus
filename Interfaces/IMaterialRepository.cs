using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IMaterialRepository
    {
        public ICollection<Material> GetMaterials();
        public Material GetMaterialById(int id);
        public bool MaterialExists(int id);
        public bool CreateMaterial(Material material);
        public bool UpdateMaterial(Material material);
        public bool DeleteMaterial(Material material);
        public bool Save();
    }
}
