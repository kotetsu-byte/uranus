using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IUserCourseRepository
    {
        Task<ICollection<UserCourse>> GetAllUserCourses();
        Task<UserCourse> GetUserCourseById(int userId, int courseId);
        bool Create(UserCourse userCourse);
        bool Update(UserCourse userCourse);
        bool Delete(int userId, int courseId);
        bool Save();
    }
}
