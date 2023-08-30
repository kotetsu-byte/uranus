using Uranus.Data;
using Uranus.Exceptions;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _context;

        public LoginRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Login> GetLogins()
        {
            return _context.Logins.OrderBy(l => l.Id).ToList();   
        }

        public Login GetLoginById(int id)
        {
            try
            {
                return _context.Logins.Where(l => l.Id == id).First();
            }catch (Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public Login GetLoginByUsername(string username)
        {
            try 
            {
                return _context.Logins.Where(l => l.Username == username).First();
            } catch(Exception ex)
            {
                throw new NotFoundException();
            }
        }

        public bool LoginExists(int id)
        {
            return _context.Logins.Any(l => l.Id == id);
        }

        public bool CreateLogin(Login login)
        {
            if (!LoginExists(login.Id))
                throw new NotFoundException();

            _context.Add(login);

            return Save();
        }

        public bool UpdateLogin(Login login) 
        { 
            if(!LoginExists(login.Id))
                throw new NotFoundException();

            _context.Update(login);

            return Save();
        }

        public bool DeleteLogin(Login login) 
        { 
            if(!LoginExists(login.Id))
                throw new NotFoundException();

            _context.Remove(login);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); ;

            return saved > 0 ? true : false;
        }
    }
}
