using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Uranus.Token
{
    public class AuthOptions
    {
        public const string ISSUER = "Uranus";
        public const string AUDIENCE = "UranusUsers";
        const string KEY = "uranus_napa";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
