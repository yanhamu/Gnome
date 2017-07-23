using System.Collections;
using System.Collections.Generic;

namespace Gnome.Core.Service.Transactions.RowFactories
{
    public class TransactionTemplate : IEnumerable<string>
    {
        private List<string> fields = new List<string>();

        public IEnumerator<string> GetEnumerator()
        {
            return fields.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return fields.GetEnumerator();
        }

        public TransactionTemplate() { }
        public TransactionTemplate(List<string> fields)
        {
            this.fields = fields;
        }
    }
}