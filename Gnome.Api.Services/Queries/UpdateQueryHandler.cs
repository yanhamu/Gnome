using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Query;
using MediatR;

namespace Gnome.Api.Services.Queries
{
    public class UpdateQueryHandler : IRequestHandler<UpdateQuery, QueryModel>
    {
        private readonly IQueryRepository repository;
        private readonly IQueryDataService service;

        public UpdateQueryHandler(IQueryRepository queryRepository, IQueryDataService queryDataservice)
        {
            this.repository = queryRepository;
            this.service = queryDataservice;
        }

        public QueryModel Handle(UpdateQuery message)
        {
            var query = repository.Find(message.Id);
            var data = new QueryData(message.ExcludeExpressions, message.IncludeExpressions, message.Accounts);
            query.Data = service.Serialize(data);
            query.Name = message.Name;
            repository.Save();

            return new QueryModel()
            {
                Accounts = message.Accounts,
                Name = query.Name,
                ExcludeExpressions = data.ExcludeExpressions,
                IncludeExpressions = data.IncludeExpressions,
                QueryId = query.Id
            };
        }
    }
}