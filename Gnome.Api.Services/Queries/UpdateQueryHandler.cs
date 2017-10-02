using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;

namespace Gnome.Api.Services.Queries
{
    public class UpdateQueryHandler : QueryHandler<UpdateQuery, Model>
    {
        public UpdateQueryHandler(IQueryRepository queryRepository) : base(queryRepository) { }

        public override Model Handle(UpdateQuery message)
        {
            var query = repository.Find(message.Id);
            var data = new QueryData(message.ExcludeExpressions, message.IncludeExpressions, message.Accounts);
            query.Data = Serialize(data);
            query.Name = message.Name;
            repository.Save();

            return new Model()
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
