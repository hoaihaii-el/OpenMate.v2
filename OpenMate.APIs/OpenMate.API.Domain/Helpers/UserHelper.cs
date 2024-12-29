using System.Security.Cryptography;
using System.Text;

namespace OpenMate.API.Domain.Helpers
{
    public class UserHelper
    {
        // Generate password hash function
        public static string GeneratePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(passwordHash);
        }
    }
}
