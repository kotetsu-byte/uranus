using Uranus.Data;
using Uranus.Exceptions;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly DataContext _context;

        public MaterialRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Material> GetMaterials()
        {
            return _context.Materials.OrderBy(m => m.Id).ToList();
        }

        public Material GetMaterialById(int id)
        {
            try
            {
                return _context.Materials.Where(m => m.Id == id).First();
            }
            catch (Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public bool MaterialExists(int id)
        {
            return _context.Materials.Any(m => m.Id == id);
        }

        public bool CreateMaterial(Material material)
        {
            if (MaterialExists(material.Id))
                throw new NotFoundException();

            _context.Materials.Add(material);

            return Save();
        }

        public bool UpdateMaterial(Material material)
        {
            if (!MaterialExists(material.Id))
                throw new NotFoundException();

            _context.Materials.Update(material);

            return Save();
        }

        public bool DeleteMaterial(Material material)
        {
            if (!MaterialExists(material.Id))
                throw new NotFoundException();

            _context.Materials.Remove(material);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
