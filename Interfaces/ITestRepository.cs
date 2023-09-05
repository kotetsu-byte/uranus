using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface ITestRepository
    {
        public ICollection<Test> GetTests();
        public Test GetTestById(int id);
        public bool TestExists(int id);
        public bool CreateTest(Test test);
        public bool UpdateTest(Test test);
        public bool DeleteTest(Test test);
        public bool Save();
    }
}
