namespace Gnome.Core.Reports.CategoryAggregateReport.Model
{
    public class CategoryAggregate
    {
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }

        public CategoryAggregate(int categoryId, decimal amount)
        {
            this.CategoryId = categoryId;
            this.Amount = amount;
        }
    }
}
