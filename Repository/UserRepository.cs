using Uranus.Data;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) { 
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            
            return _context.Users.OrderBy(p => p.Id).ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public User GetUserByLogin(string login)
        {
            return _context.Users.Where(p => p.Login == login).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(p => p.Email == email).FirstOrDefault();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(p => p.Id == id);
        }

        public bool CreateUser(User user, string login, string email, string password) 
        {
            
            user.Login = login;
            user.Email = email;
            user.Password = password;

            _context.Add(user);

            return Save();
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);

            return Save();
        }

        public bool DeleteUser(User user) 
        {
            _context.Remove(user);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
