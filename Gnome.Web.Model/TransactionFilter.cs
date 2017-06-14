using System.Collections.Generic;

namespace Gnome.Web.Model
{
    public class TransactionFilter
    {
        public IEnumerable<string> FieldsToDisplay { get; set; }
        public int? Page { get; set; }
        public int? MaxItems { get; set; }
    }
}
