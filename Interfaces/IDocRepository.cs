using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IDocRepository
    {
        public ICollection<Doc> GetDocs();
        public Doc GetDocById(int id);
        public bool DocExists(int id);
        public bool CreateDoc(Doc doc);
        public bool UpdateDoc(Doc doc);
        public bool DeleteDoc(Doc doc);
        public bool Save();
    }
}
