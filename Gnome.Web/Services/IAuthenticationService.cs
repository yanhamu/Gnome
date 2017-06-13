using Gnome.Web.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Gnome.Web.Services
{
    public interface IAuthenticationService
    {
        Task LogIn(LoginUser user, HttpContext httpContext);
        void LogOut(HttpContext httpContext);
    }
}
