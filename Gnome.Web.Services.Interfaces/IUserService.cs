using Gnome.Web.Model.ViewModel;
using System.Threading.Tasks;

namespace Gnome.Web.Services.Interfaces
{
    public interface IUserService
    {
        bool Register(UserRegistration user);
        bool Verify(LoginUser user);
    }
}
