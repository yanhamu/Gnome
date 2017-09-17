using Gnome.Core.Model.Database;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public interface IUserRepository
    {
        bool CheckEmailAvailability(string email);
        User GetUser(string email);
    }

    public class UserRepository : IUserRepository
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
