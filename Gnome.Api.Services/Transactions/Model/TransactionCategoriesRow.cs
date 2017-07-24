using Gnome.Core.Service.Transactions;
using System.Collections.Generic;

namespace Gnome.Api.Services.Transactions.Model
{
    public class TransactionCategoriesRow
    {
        public TransactionRow Row { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
