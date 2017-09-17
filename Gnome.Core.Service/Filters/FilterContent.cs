using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Filters
{
    public class FilterContent
    {
        public List<Guid> Included { get; }
        public List<Guid> Excluded { get; }
        public List<Guid> Accounts { get; }

        public FilterContent(
             List<Guid> included,
             List<Guid> excluded,
             List<Guid> accounts
            )
        {
            this.Included = included;
            this.Excluded = excluded;
            this.Accounts = accounts;
        }

        public static FilterContent Create(string content)
        {
            return JsonConvert.DeserializeObject<FilterContent>(content);
        }

        public static string Create(FilterContent content)
        {
            return JsonConvert.SerializeObject(content);
        }

        public static string Create(Model.Filter filter)
        {
            return Create(new FilterContent(
                filter.Included.Select(e => e.Id).ToList(),
                filter.Excluded.Select(e => e.Id).ToList(), 
                filter.Accounts));
        }
    }
}
