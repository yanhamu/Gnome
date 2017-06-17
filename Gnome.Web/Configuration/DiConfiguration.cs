using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gnome.Infrastructure;
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
            var containerBuilder = ContainerInitializer.CreateContainer();

            containerBuilder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            containerBuilder.RegisterType<TransactionService>().As<ITransactionService>();

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }
    }
}