using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Gnome.Core.Service
{
    public class UserSecurityService : IUserSecurityService
    {
        public byte[] GetSalt()
        {
            return GetSalt(128);
        }

        public byte[] CreatePassword(string password, byte[] salt)
        {
            var pwd = Encoding.UTF8.GetBytes(password);
            var passwordWithSalt = salt.Concat(pwd).ToArray();

            using (var sha = SHA256.Create())
            {
                return sha.ComputeHash(passwordWithSalt);
            }
        }
        
        public bool Verify(string password, byte[] hashed, byte[] salt)
        {
            var pwd = CreatePassword(password, salt);
            return hashed.SequenceEqual(pwd);
        }

        private byte[] GetSalt(int bitLength)
        {
            var salt = new byte[bitLength / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
    }
}
