namespace Gnome.Api.Services
{
    public class PaginationResult
    {
        public int PageSize { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageTotal { get; private set; }

        public PaginationResult(int pageSize, int currentPage, int pageTotal)
        {
            this.PageSize = pageSize;
            this.CurrentPage = currentPage;
            this.PageTotal = pageTotal;
        }

        public static PaginationResult CreateFromTotal(int pageSize, int currentPage, int totalRows)
        {
            return new PaginationResult(pageSize, currentPage, (totalRows + pageSize - 1) / pageSize);
        }
    }
}
