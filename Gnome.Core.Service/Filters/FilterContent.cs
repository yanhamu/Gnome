using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
    }
}
