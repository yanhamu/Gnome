using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Model.Database;

namespace Gnome.Api.Services.Queries
{
    public class CreateQueryHandler : QueryHandler<CreateQuery, Model>
    {
        public CreateQueryHandler(IQueryRepository queryRepository) : base(queryRepository) { }

        public override Model Handle(CreateQuery message)
        {
            var query = new Query()
            {
                Data = Serialize(new QueryData(message.ExcludeExpressions, message.IncludeExpressions, message.Accounts)),
                Name = message.Name,
                UserId = message.UserId
            };

            var saved = repository.Create(query);
            repository.Save();

            var data = Deserialize(saved.Data);
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
