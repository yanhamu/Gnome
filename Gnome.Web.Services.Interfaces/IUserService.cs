using Gnome.Web.Model;
using Gnome.Web.Model.ViewModel;

namespace Gnome.Web.Services.Interfaces
{
    public interface IUserService
    {
        bool Register(UserRegistration user);
        User Verify(LoginUser user);
    }
}
