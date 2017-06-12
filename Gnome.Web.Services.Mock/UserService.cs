using Gnome.Web.Model;
using Gnome.Web.Services.Interfaces;
using System.Threading.Tasks;

namespace Gnome.Web.Services.Mock
{
    public class UserService : IUserService
    {
        public Task<User> Get()
        {
            return Task.Run(() => new User() { IsAuthenticated = true });
        }
    }
}
