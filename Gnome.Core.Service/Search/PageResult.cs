namespace Gnome.Core.Service.Search
{
    public class PageResult
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }

        public PageResult(int pageNumber, int pageSize, int totalRows)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalRows = totalRows;
            this.TotalPages = totalRows / pageSize;
        }
    }
}
