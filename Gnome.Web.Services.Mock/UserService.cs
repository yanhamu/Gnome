using Gnome.Web.Model;
using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using System.Collections.Generic;

namespace Gnome.Web.Services.Mock
{
    public class UserService : IUserService
    {
        public static List<User> Users = new List<User>();


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

        public User Verify(LoginUser user)
        {
            if (user.Email != "kriskatomas360@gmail.com")
            {
                return null;
            }
            else
            {
                return new User() { Email = "kriskatomas360@gmail.com", Id = 1, IsAuthenticated = true };
            }

        }
    }
}