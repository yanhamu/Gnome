using System.Collections.Generic;

namespace Gnome.Web.Model.ViewModel
{
    public class MaskedTransactionList
    {
        public TransactionMask Mask { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
