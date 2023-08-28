using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers();
        public User GetUserById(int id);
        public User GetUserByLogin(string login);
        public User GetUserByEmail(string email);
        public bool UserExists(int id);
        public bool CreateUser(User user, string login, string email, string password);
        public bool UpdateUser(User user);
        public bool DeleteUser(User user);
        public bool Save();
    }
}
