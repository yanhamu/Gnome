using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.Query;
using MediatR;

namespace Gnome.Api.Services.Queries
{
    public class CreateQueryHandler : IRequestHandler<CreateQuery, Model>
    {
        private readonly IQueryRepository repository;
        private readonly IQueryDataService service;

        public CreateQueryHandler(IQueryRepository queryRepository, IQueryDataService queryDataservice)
        {
            this.repository = queryRepository;
            this.service = queryDataservice;
        }

        public Model Handle(CreateQuery message)
        {
            var query = new Query()
            {
                Data = service.Serialize(new QueryData(message.ExcludeExpressions, message.IncludeExpressions, message.Accounts)),
                Name = message.Name,
                UserId = message.UserId
            };

            var saved = repository.Create(query);
            repository.Save();

            var data = service.Deserialize(saved.Data);
            return new Model()
            {
                QueryId = saved.Id,
                Name = saved.Name,
                Accounts = data.Accounts,
                ExcludeExpressions = data.ExcludeExpressions,
                IncludeExpressions = data.IncludeExpressions
            };
        }
    }
}
