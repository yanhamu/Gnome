using System.Collections.Generic;

namespace Gnome.Core.Service.Transactions
{
    public class TransactionCategoryRow
    {
        public TransactionRow Row { get; }
        public List<Category> Categories { get; }

        public TransactionCategoryRow(TransactionRow row, List<Category> categories)
        {
            this.Row = row;
            this.Categories = categories;
        }
    }
}