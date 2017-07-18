using System;

namespace Gnome.Core.Reports.CategoryAggregateReport.DataAccess
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
