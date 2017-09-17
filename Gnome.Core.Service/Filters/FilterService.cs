using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Filters
{
    public class FilterService
    {
        private readonly IFilterRepository filterRepository;
        private IExpressionRepository expressionRepository;

        public FilterService(
            IFilterRepository filterRepository,
            IExpressionRepository expressionRepository)
        {
            this.filterRepository = filterRepository;
            this.expressionRepository = expressionRepository;
        }

        public Model.Filter Get(Guid id)
        {
            var filter = filterRepository.Find(id);
            var content = FilterContent.Create(filter.Content);
            var expressions = expressionRepository
                .Query
                .Where(e => content.Included.Contains(e.Id))
                .Where(e => !content.Excluded.Contains(e.Id))
                .ToList();

            return CreateFilter(filter, expressions);
        }

        public List<Model.Filter> List(Guid userId)
        {
            var expressions = expressionRepository
                .Query
                .Where(e => e.UserId == userId)
                .ToList();

            return filterRepository
                .Query
                .Where(f => f.UserId == userId)
                .ToList()
                .Select(f => CreateFilter(f, expressions))
                .ToList();
        }

        private Model.Filter CreateFilter(Filter f, List<Expression> expressions)
        {
            var filterContent = FilterContent.Create(f.Content);

            var filter = new Model.Filter()
            {
                Id = f.Id,
                Name = f.Name,
                Accounts = filterContent.Accounts,
                Excluded = GetExpressions(filterContent.Excluded, expressions),
                Included = GetExpressions(filterContent.Included, expressions)
            };
            return filter;
        }

        private List<Expression> GetExpressions(List<Guid> ids, List<Expression> expressions)
        {
            return expressions.Where(e => ids.Contains(e.Id)).ToList();
        }
    }
}
