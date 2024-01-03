using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByUsername(string username);
        public bool Exists(int id);
        public bool Create(User user);
        public bool Update(User user);
        public bool Delete(int id);
        public bool Save();
    }
}
