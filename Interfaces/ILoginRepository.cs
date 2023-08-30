using Uranus.Models;

namespace Uranus.Interfaces
{
    public interface ILoginRepository
    {
        public ICollection<Login> GetLogins();
        public Login GetLoginById(int id);
        public Login GetLoginByUsername(string username);
        public bool LoginExists(int id);
        public bool CreateLogin(Login login);
        public bool UpdateLogin(Login login);
        public bool DeleteLogin(Login login);
        public bool Save();
    }
}
