namespace Gnome.Core.Model
{
    public class CategoryTransaction
    {
        public int CategoryId { get; set; }
        public int TransactionId { get; set; }
        public Category Category { get; set; }
        public FioTransaction Transaction { get; set; }
    }
}
