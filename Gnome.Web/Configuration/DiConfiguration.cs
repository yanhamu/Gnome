using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gnome.Web.Services;
using Gnome.Web.Services.Interfaces;
using Gnome.Web.Services.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace Gnome.Web.Configuration
{
    public static class DiConfiguration
    {
        public static IContainer CreateContainer(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            containerBuilder.RegisterType<AccountService>().As<IAccountService>();

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }
    }
}