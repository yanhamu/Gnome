using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.Query;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Queries
{
    public class CreateQueryHandler : IRequestHandler<CreateQuery, QueryModel>
    {
        private readonly IQueryRepository repository;
        private readonly IQueryDataService service;
        private readonly IQueryService queryService;

        public CreateQueryHandler(
            IQueryRepository queryRepository,
            IQueryDataService queryDataservice,
            IQueryService queryService)
        {
            this.repository = queryRepository;
            this.service = queryDataservice;
            this.queryService = queryService;
        }

        public async Task<QueryModel> Handle(CreateQuery message, CancellationToken cancellationToken)
        {
            var query = new Query()
            {
                Data = service.Serialize(new QueryData(message.ExcludeExpressions, message.IncludeExpressions, message.Accounts)),
                Name = message.Name,
                UserId = message.UserId
            };

            var saved = repository.Create(query);
            await repository.Save();

            return queryService.Get(saved);
        }
    }
}
