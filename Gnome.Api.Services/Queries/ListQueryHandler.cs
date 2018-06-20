using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Queries
{
    public class ListQueryHandler : IRequestHandler<ListQueries, List<QueryModel>>
    {
        private readonly IQueryRepository repository;
        private readonly IQueryService queryService;

        public ListQueryHandler(
            IQueryRepository queryRepository,
            IQueryService queryService)
        {
            this.repository = queryRepository;
            this.queryService = queryService;
        }

        public async Task<List<QueryModel>> Handle(ListQueries message, CancellationToken cancellationToken)
        {
            return (await repository
                .Query
                .Where(q => q.UserId == message.UserId)
                .ToListAsync())
                .Select(m => queryService.Get(m))
                .ToList();
        }
    }
}
