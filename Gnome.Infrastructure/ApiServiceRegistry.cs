using Gnome.Api.Services.Transactions;
using Gnome.Api.Services.Transactions.Requests;
using Gnome.Api.Services.Users;
using MediatR;
using MediatR.Pipeline;
using StructureMap;
using System;

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

                For(typeof(IPipelineBehavior<,>)).Add(typeof(SearchTransactionHandlerDecorator));
                //For(typeof(RequestPostProcessorBehavior<CreateTransaction, Guid>)).Add(typeof(RequestPostProcessorBehavior<CreateTransaction, Guid>));
                For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestPostProcessorBehavior<,>));
            });
        }
    }
}
