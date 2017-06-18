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

            builder.RegisterType<Gnome.Web.Services.AccountService>().As<Gnome.Web.Services.Interfaces.IAccountService>();
            builder.RegisterType<Gnome.Web.Services.UserService>().As<Gnome.Web.Services.Interfaces.IUserService>();
            builder.RegisterType<Gnome.Web.Services.TransactionService>().As<Gnome.Web.Services.Interfaces.ITransactionService>();

            builder.RegisterType<UserRepository>();
            builder.RegisterType<UserSecurityRepository>();
            builder.RegisterType<AccountRepository>();
            builder.RegisterType<TransactionRepository>();

            return builder;
        }
    }
}
