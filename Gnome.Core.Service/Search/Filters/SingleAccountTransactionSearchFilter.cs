namespace Gnome.Core.Service.Search.Filters
{
    public class SingleAccountTransactionSearchFilter
    {
        public PageFilter PageFilter { get; set; }
        public Interval DateFilter { get; set; }
        public int AccountId { get; set; }
    }
}