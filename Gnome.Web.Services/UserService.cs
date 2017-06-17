using Gnome.Web.Model;
using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;

namespace Gnome.Web.Services
{
    public class UserService : IUserService
    {
        private readonly Core.Service.Interfaces.IUserService userService;

        public UserService(Core.Service.Interfaces.IUserService userService)
        {
            this.userService = userService;
        }

        public int Register(UserRegistration user)
        {
            return userService.CreateNew(user.Email, user.Password);
        }

        public User Verify(string email, string password)
        {
            var result = userService.Verify(email, password);
            if (result == null)
                return null;

            return new User() { Id = result.Id, Email = result.Email };
        }
    }
}
