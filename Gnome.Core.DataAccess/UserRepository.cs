using Gnome.Core.Model.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Gnome.Core.DataAccess
{
    public interface IUserRepository
    {
        Task<bool> CheckEmailAvailability(string email);
        Task<User> GetUser(string email);
    }

    public class UserRepository : IUserRepository
    {
        private readonly GnomeDb context;

        public UserRepository(GnomeDb context)
        {
            this.context = context;
        }

        public async Task<bool> CheckEmailAvailability(string email)
        {
            var user = await context.Users.Where(u => u.Email == email).SingleOrDefaultAsync();
            return user == null;
        }

        public Task<User> GetUser(string email)
        {
            return context.Users.Where(u => u.Email == email).SingleOrDefaultAsync();
        }
    }
}
