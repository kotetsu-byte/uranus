using Uranus.Data;
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
            return _context.Homeworks.Where(l => l.Id == id).FirstOrDefault();
        }

        public Homework GetHomeworkByTitle(string title)
        {
            return _context.Homeworks.Where(l => l.Title == title).FirstOrDefault(); 
        }

        public bool HomeworkExists(int id)
        {
            return _context.Homeworks.Any(l => l.Id == id);
        }

        public string[] GetMaterials(int id)
        {
            var homework = _context.Homeworks.Where(h => h.Id == id).FirstOrDefault();

            return homework.Materials;
        }

        public bool CreateHomework(Homework homework, int lessonId, string title, string description, string[] materials, DateTime deadline, bool isDone)
        {
            homework.Title = title;
            homework.Description = description;
            homework.Materials = materials;
            homework.Deadline = deadline;
            homework.IsDone = isDone;
            homework.Lesson.Id = lessonId;

            _context.Homeworks.Add(homework);

            return Save();
        }

        public bool UpdateHomework(Homework homework)
        {
            _context.Update(homework);

            return Save();
        }

        public bool DeleteHomework(Homework homework) 
        {
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
