using MediatR;
using System;

namespace Gnome.Api.Services.CategoryTransactions.Requests
{
    public class CreateCategoryTransaction : IRequest
    {
        public Guid TransactionId { get; set; }
        public int CategoryId { get; set; }

        public CreateCategoryTransaction(int categoryId, Guid transactionId)
        {
            this.CategoryId = categoryId;
            this.TransactionId = transactionId;
        }
    }
}
