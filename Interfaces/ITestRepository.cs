using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface ITestRepository
    {
        public Task<ICollection<Test>> GetAllTests(int courseId);
        public Task<Test> GetTestById(int courseId, int id);
        public bool Exists(int id);
        public bool Exists(int courseId, int id);
        public bool Create(Test test);
        public bool Update(Test test);
        public bool Delete(int id);
        public bool Save();
    }
}
