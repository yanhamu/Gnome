using Gnome.Web.Model;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Gnome.Web.Services
{
    public interface IAuthenticationService
    {
        Task LogIn(User user, HttpContext httpContext);
        void LogOut(HttpContext httpContext);
    }
}
