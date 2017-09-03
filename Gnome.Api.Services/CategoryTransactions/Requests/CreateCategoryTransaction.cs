using MediatR;
using System;

namespace Gnome.Api.Services.CategoryTransactions.Requests
{
    public class CreateCategoryTransaction : IRequest
    {
        public Guid TransactionId { get; set; }
        public Guid CategoryId { get; set; }

        public CreateCategoryTransaction(Guid categoryId, Guid transactionId)
        {
            this.CategoryId = categoryId;
            this.TransactionId = transactionId;
        }
    }
}
