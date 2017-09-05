using Gnome.Api.IntegrationTests.Fixtures;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Gnome.Api.IntegrationTests.Configuration
{
    public class IdentityMiddleware
    {
        private RequestDelegate next;

        public IdentityMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.User = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new GenericIdentity(""), new Claim[] {
                        new Claim("user_id", UserFixture.User.Id.ToString())
                    }));

            await next.Invoke(context);
        }
    }
}
