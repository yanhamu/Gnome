using Gnome.Core.Model;
using MediatR;

namespace Gnome.Api.Services.Transactions
{
    public class CreateFioTransaction : IRequest<int>
    {
        public FioTransaction Transaction { get; set; }

        public CreateFioTransaction(FioTransaction transaction)
        {
            this.Transaction = transaction;
        }
    }
}
