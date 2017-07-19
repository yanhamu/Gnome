using Gnome.Web.Model;
using Gnome.Web.Model.ViewModel;

namespace Gnome.Web.Services.Interfaces
{
    public interface IUserService
    {
        int Register(UserRegistration user);
        User Verify(string email, string password);
    }
}
