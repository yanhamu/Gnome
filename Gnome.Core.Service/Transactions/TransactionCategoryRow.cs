using System;
using System.Collections.Generic;
using System.Text;

namespace Gnome.Core.Service.Transactions
{
    public class TransactionCategoryRow
    {
        public TransactionRow Row { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
