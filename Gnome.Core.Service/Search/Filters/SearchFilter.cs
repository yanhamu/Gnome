namespace Gnome.Core.Service.Search.Filters
{
    public class SearchFilter
    {
        public PageFilter PageFilter { get; set; }
        public Interval DateFilter { get; set; }
        public AccountsFilter AccountsFilter { get; set; }
    }
}