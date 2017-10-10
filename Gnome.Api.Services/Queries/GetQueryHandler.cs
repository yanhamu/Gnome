using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Query;
using MediatR;

namespace Gnome.Api.Services.Queries
{
    public class GetQueryHandler : IRequestHandler<GetQuery, QueryModel>
    {
        private readonly IQueryDataService service;
        private readonly IQueryRepository repository;

        public GetQueryHandler(IQueryRepository queryRepository, IQueryDataService service)
        {
            this.service = service;
            this.repository = queryRepository;
        }

        public QueryModel Handle(GetQuery message)
        {
            var result = repository.Find(message.QueryId);
            var data = service.Deserialize(result.Data);
            return new QueryModel()
            {
                Accounts = data.Accounts,
                ExcludeExpressions = data.ExcludeExpressions,
                IncludeExpressions = data.IncludeExpressions,
                Name = result.Name,
                QueryId = result.Id
            };
        }
    }
}
