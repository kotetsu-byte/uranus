using Uranus.Data;
using Uranus.Exceptions;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class DocRepository : IDocRepository
    {
        private readonly DataContext _context;

        public DocRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Doc> GetDocs()
        {
            return _context.Docs.OrderBy(d => d.Id).ToList();
        }

        public Doc GetDocById(int id)
        {
            try
            {
                return _context.Docs.Where(d => d.Id == id).First();
            } catch (Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public bool DocExists(int id)
        {
            return _context.Docs.Any(d => d.Id == id);
        }

        public bool CreateDoc(Doc doc)
        {
            if (DocExists(doc.Id))
                throw new NotFoundException();

            _context.Docs.Add(doc);

            return Save();
        }

        public bool UpdateDoc(Doc doc)
        {
            if (!DocExists(doc.Id))
                throw new NotFoundException();

            _context.Docs.Update(doc);

            return Save();
        }

        public bool DeleteDoc(Doc doc)
        {
            if (!DocExists(doc.Id))
                throw new NotFoundException();

            _context.Docs.Remove(doc);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
