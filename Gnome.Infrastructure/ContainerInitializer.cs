using Autofac;
using Gnome.Core.DataAccess;
using Gnome.Core.Service;
using Gnome.Core.Service.Interfaces;

namespace Gnome.Infrastructure
{
    public class ContainerInitializer
    {
        public static ContainerBuilder CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UserSecurityService>();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<UserRepository>();
            builder.RegisterType<UserSecurityRepository>();

            return builder;
        }
    }
}
