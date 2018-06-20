using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Queries
{
    public class RemoveQueryHandler : INotificationHandler<RemoveQuery>
    {
        private readonly IQueryRepository repository;

        public RemoveQueryHandler(IQueryRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveQuery removeQuery, CancellationToken cancellationToken)
        {
            repository.Remove(removeQuery.QueryId);
            await repository.Save();
        }
    }
}