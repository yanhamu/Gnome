using Gnome.Web.Model;
using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gnome.Web.Services.Mock
{
    public class UserService : IUserService
    {
        public static List<User> Users = new List<User>();

        public Task<User> Get()
        {
            return Task.Run(() => new User() { IsAuthenticated = true });
        }

        public bool Register(UserRegistration user)
        {
            if (user.Email == "kriskatomas360@gmail.com")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Verify(LoginUser user)
        {
            return user.Email == "kriskatomas360@gmail.com";
        }
    }
}