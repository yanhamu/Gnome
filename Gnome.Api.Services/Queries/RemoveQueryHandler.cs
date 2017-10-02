using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using MediatR;

namespace Gnome.Api.Services.Queries
{
    public class RemoveQueryHandler : INotificationHandler<RemoveQuery>
    {
        private readonly IQueryRepository repository;

        public RemoveQueryHandler(IQueryRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(RemoveQuery removeQuery)
        {
            repository.Remove(repository.Find(removeQuery.QueryId));
            repository.Save();
        }
    }
}