using MediatR;
using System;

namespace Gnome.Api.Services.CategoryTransactions.Requests
{
    public class RemoveCategoryTransaction : IRequest
    {
        public Guid TransactionId { get; set; }
        public Guid CategoryId { get; set; }

        public RemoveCategoryTransaction(Guid categoryId, Guid transactionId)
        {
            this.CategoryId = categoryId;
            this.TransactionId = transactionId;
        }
    }
}
