using Gnome.Api.Services.CategoryTransactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.CategoryTransactions
{
    public class CategoryTransactionHandler :
        INotificationHandler<CreateCategoryTransaction>,
        INotificationHandler<RemoveCategoryTransaction>
    {
        private readonly ICategoryTransactionRepository repository;

        public CategoryTransactionHandler(ICategoryTransactionRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateCategoryTransaction message, CancellationToken cancellationToken)
        {
            this.repository.Create(new CategoryTransaction() { CategoryId = message.CategoryId, TransactionId = message.TransactionId });
            await this.repository.Save();
        }

        public async Task Handle(RemoveCategoryTransaction message, CancellationToken cancellationToken)
        {
            this.repository.Remove(message.CategoryId, message.TransactionId);
            await this.repository.Save();
        }
    }
}