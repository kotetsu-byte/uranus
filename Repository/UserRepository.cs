using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Uranus.Data;
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

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _context.Users.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public bool Exists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public bool Create(User user)
        {
            _context.Users.Add(user);

            return Save();
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);

            return Save();
        }

        public bool Delete(int id)
        {
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            
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
