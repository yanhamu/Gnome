using MediatR;
using System;

namespace Gnome.Api.Services.CategoryTransactions.Requests
{
    public class RemoveCategoryTransaction : IRequest
    {
        public Guid TransactionId { get; set; }
        public int CategoryId { get; set; }

        public RemoveCategoryTransaction(int categoryId, Guid transactionId)
        {
            this.CategoryId = categoryId;
            this.TransactionId = transactionId;
        }
    }
}
