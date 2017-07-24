using MediatR;

namespace Gnome.Api.Services.CategoryTransactions.Requests
{
    public class CreateCategoryTransaction : IRequest
    {
        public int TransactionId { get; set; }
        public int CategoryId { get; set; }

        public CreateCategoryTransaction(int categoryId, int transactionId)
        {
            this.CategoryId = categoryId;
            this.TransactionId = transactionId;
        }
    }
}
