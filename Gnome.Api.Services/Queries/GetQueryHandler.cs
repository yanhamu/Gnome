using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Query;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Queries
{
    public class GetQueryHandler : IRequestHandler<GetQuery, QueryModel>
    {
        private readonly IQueryService service;
        private readonly IQueryRepository repository;

        public GetQueryHandler(IQueryRepository queryRepository, IQueryService service)
        {
            this.service = service;
            this.repository = queryRepository;
        }

        public async Task<QueryModel> Handle(GetQuery message, CancellationToken cancellationToken)
        {
            var result = await repository.Find(message.QueryId);
            return service.Get(result);
        }
    }
}