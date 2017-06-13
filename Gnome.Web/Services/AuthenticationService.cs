using Gnome.Web.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gnome.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public const string COOKIE_MIDDLEWARE = "GAUTH";
        public async Task LogIn(User user, HttpContext httpContext)
        {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.Id.ToString())
            };
            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "cookie"));

            await httpContext.Authentication.SignInAsync(COOKIE_MIDDLEWARE, principal);
        }


        public void LogOut(HttpContext httpContext)
        {
            httpContext.Authentication.SignOutAsync(COOKIE_MIDDLEWARE);
        }
    }
}
