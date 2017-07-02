using Autofac;
using Gnome.Web.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Gnome.Web
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(new AuthorizeFilter(
                    new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build()));
            });

            var container = DiConfiguration.CreateContainer(services);

            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = Services.AuthenticationService.COOKIE_MIDDLEWARE,
                LoginPath = new Microsoft.AspNetCore.Http.PathString("/Authentication/Login"),
                AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Authentication/Forbidden/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    RouteNames.TransactionList,
                    "account/{accountId}/transactions",
                    new { controller = "Transaction", action = "List" });

                routes.MapRoute(
                       name: "default",
                       template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
