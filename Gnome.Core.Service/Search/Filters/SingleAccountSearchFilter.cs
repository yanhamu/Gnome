namespace Gnome.Core.Service.Search.Filters
{
    public class SingleAccountSearchFilter
    {
        public PageFilter PageFilter { get; set; }
        public Interval DateFilter { get; set; }
        public int AccountId { get; set; }
    }
}