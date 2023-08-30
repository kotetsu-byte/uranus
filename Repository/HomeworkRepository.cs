using Uranus.Data;
using Uranus.Exceptions;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly DataContext _context;

        public HomeworkRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Homework> GetHomeworks()
        {
            return _context.Homeworks.OrderBy(h => h.Id).ToList();
        }

        public Homework GetHomeworkById(int id)
        {
            try
            {
                return _context.Homeworks.Where(l => l.Id == id).First();
            } catch(Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public Homework GetHomeworkByTitle(string title)
        {
            try
            {
                return _context.Homeworks.Where(l => l.Title == title).First();
            } catch(Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public bool HomeworkExists(int id)
        {
            return _context.Homeworks.Any(l => l.Id == id);
        }

        public string[] GetMaterials(int id)
        {
            var homework = _context.Homeworks.Where(h => h.Id == id).First();

            try
            {
                return homework.Materials;
            } catch(Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public bool CreateHomework(Homework homework)
        {
            if (!HomeworkExists(homework.Id))
                throw new NotFoundException();
            
            _context.Homeworks.Add(homework);

            return Save();
        }

        public bool UpdateHomework(Homework homework)
        {
            if (!HomeworkExists(homework.Id))
                throw new NotFoundException();

            _context.Update(homework);

            return Save();
        }

        public bool DeleteHomework(Homework homework)
        {
            if (!HomeworkExists(homework.Id))
                throw new NotFoundException();

            _context.Remove(homework);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
