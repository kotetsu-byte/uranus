using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface ILessonRepository
    {
        public ICollection<Lesson> GetLessons();
        public Lesson GetLessonById(int id);
        public bool LessonExists(int id);
        public string[] GetVideos(int id);
        public string[] GetDocs(int id);
        public bool CreateLesson(Lesson lesson, int courseId, string info, string[] videos, string[] docs);
        public bool UpdateLesson(Lesson lesson);
        public bool DeleteLesson(Lesson lesson);
        public bool Save();
    }
}
