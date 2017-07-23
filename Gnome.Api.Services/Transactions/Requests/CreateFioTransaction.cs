using Gnome.Core.Model;
using MediatR;
using System;

namespace Gnome.Api.Services.Transactions.Requests
{
    public class CreateFioTransaction : IRequest<Guid>
    {
        public FioTransaction Transaction { get; set; }

        public CreateFioTransaction(FioTransaction transaction)
        {
            this.Transaction = transaction;
        }
    }
}
