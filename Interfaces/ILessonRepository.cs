using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface ILessonRepository
    {
        public ICollection<Lesson> GetLessons();
        public Lesson GetLessonById(int id);
        public bool LessonExists(int id);
        public ICollection<Video> GetVideos(int id);
        public ICollection<Doc> GetDocs(int id);
        public bool CreateLesson(Lesson lesson);
        public bool UpdateLesson(Lesson lesson);
        public bool DeleteLesson(Lesson lesson);
        public bool Save();
    }
}
