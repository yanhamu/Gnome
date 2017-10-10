using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Query;
using MediatR;

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

        public QueryModel Handle(GetQuery message)
        {
            var result = repository.Find(message.QueryId);
            return service.Get(result);
        }
    }
}