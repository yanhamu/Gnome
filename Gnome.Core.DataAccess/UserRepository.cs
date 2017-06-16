using Gnome.Core.Model;
using System;

namespace Gnome.Core.DataAccess
{
    public class UserRepository
    {
        public bool CheckEmailAvailability(string email)
        {
            throw new NotImplementedException();
        }

        public UserSecurity GetBy(string email)
        {
            throw new NotImplementedException();
        }

        public User CreateNew(string email, byte[] pwd, byte[] salt)
        {
            throw new NotImplementedException();
        }
    }
}
