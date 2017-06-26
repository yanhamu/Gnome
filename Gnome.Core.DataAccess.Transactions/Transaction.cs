using System;

namespace Gnome.Core.DataAccess.Transactions
{
    public abstract class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
    }
}
