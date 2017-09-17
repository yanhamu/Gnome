using Gnome.Core.DataAccess;
using System;

namespace Gnome.Core.Service.Filters
{
    public class FilterService
    {
        private readonly IFilterRepository repository;

        public FilterService(IFilterRepository filterRepository)
        {
            this.repository = filterRepository;
        }

        public object Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
