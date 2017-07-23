using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Search.QueryBuilders;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Search
{
    public interface IQueryBuilderService
    {
        IQueryable<Transaction> Filter(IQueryable<Transaction> query, SearchFilter filter);
    }

    public class QueryBuilderService : IQueryBuilderService
    {
        private readonly IEnumerable<IQueryBuilder> queryBuilders;

        public QueryBuilderService(IEnumerable<IQueryBuilder> queryBuilders)
        {
            this.queryBuilders = queryBuilders;
        }

        public IQueryable<Transaction> Filter(IQueryable<Transaction> query, SearchFilter filter)
        {
            foreach (var builder in this.queryBuilders)
                query = builder.Build(query, filter);
            return query;
        }
    }
}