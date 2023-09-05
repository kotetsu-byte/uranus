using Microsoft.AspNetCore.Http.HttpResults;
using Uranus.Data;
using Uranus.Exceptions;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(p => p.Id).ToList();
        }

        public User GetUserById(int id)
        {
            try
            {
                return _context.Users.Where(p => p.Id == id).First();
            } catch(Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                return _context.Users.Where(p => p.Username == username).First();
            } catch(Exception) 
            {
                throw new NotFoundException();
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return _context.Users.Where(p => p.Email == email).First();
            } catch(Exception ex) 
            {
                throw new NotFoundException();
            }
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(p => p.Id == id);
        }

        public bool CreateUser(User user)
        {
            if (UserExists(user.Id))
                throw new NotFoundException();
            
            _context.Users.Add(user);

            return Save();
        }

        public bool UpdateUser(User user)
        {
            if (!UserExists(user.Id))
                throw new NotFoundException();

            _context.Users.Update(user);

            return Save();
        }

        public bool DeleteUser(User user)
        {
            if (!UserExists(user.Id))
                throw new NotFoundException();

            _context.Users.Remove(user);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
