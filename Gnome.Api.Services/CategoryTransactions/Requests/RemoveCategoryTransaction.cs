using MediatR;

namespace Gnome.Api.Services.CategoryTransactions.Requests
{
    public class RemoveCategoryTransaction : IRequest
    {
        public int TransactionId { get; set; }
        public int CategoryId { get; set; }

        public RemoveCategoryTransaction(int categoryId, int transactionId)
        {
            this.CategoryId = categoryId;
            this.TransactionId = transactionId;
        }
    }
}
