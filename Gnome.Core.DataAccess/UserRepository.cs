using Gnome.Core.Model;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public class UserRepository
    {
        private readonly GnomeDb context;

        public UserRepository(GnomeDb context)
        {
            this.context = context;
        }

        public bool CheckEmailAvailability(string email)
        {
            var user = context.Users.Where(u => u.Email == email).SingleOrDefault();
            return user == null;
        }

        public User GetUser(string email)
        {
            return context.Users.Where(u => u.Email == email).SingleOrDefault();
        }
    }
}
