using Uranus.Data;
using Uranus.Exceptions;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext _context;

        public TestRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Test> GetTests()
        {
            return _context.Tests.OrderBy(t => t.Id).ToList();
        }

        public Test GetTestById(int id)
        {
            try
            {
                return _context.Tests.Where(t => t.Id == id).First();
            }
            catch (Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public bool TestExists(int id)
        {
            return _context.Tests.Any(t => t.Id == id);
        }

        public bool CreateTest(Test test)
        {
            if (TestExists(test.Id))
                throw new NotFoundException();

            _context.Tests.Add(test);

            return Save();
        }

        public bool UpdateTest(Test test)
        {
            if (!TestExists(test.Id))
                throw new NotFoundException();

            _context.Tests.Update(test);

            return Save();
        }

        public bool DeleteTest(Test test)
        {
            if (!TestExists(test.Id))
                throw new NotFoundException();

            _context.Tests.Remove(test);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
