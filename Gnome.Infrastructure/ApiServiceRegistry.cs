using Gnome.Api.Services.Transactions;
using Gnome.Api.Services.Transactions.Model;
using Gnome.Api.Services.Transactions.Requests;
using Gnome.Api.Services.Users;
using MediatR;
using StructureMap;

namespace Gnome.Infrastructure
{
    public class ApiServiceRegistry : Registry
    {
        public ApiServiceRegistry()
        {
            Scan(_ =>
            {
                _.AssemblyContainingType<RegisterUser>();
                _.Include(t => t.Name.EndsWith("Service"));
                _.Include(t => t.Name.EndsWith("Factory"));
                _.WithDefaultConventions();

                For(typeof(IPipelineBehavior<SearchTransaction, SearchTransactionResult>)).Add(typeof(SearchTransactionHandlerDecorator));
            });
        }
    }
}
