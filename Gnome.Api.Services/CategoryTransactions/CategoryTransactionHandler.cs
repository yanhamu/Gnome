using Gnome.Api.Services.CategoryTransactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using MediatR;

namespace Gnome.Api.Services.CategoryTransactions
{
    public class CategoryTransactionHandler :
        IRequestHandler<CreateCategoryTransaction>,
        IRequestHandler<RemoveCategoryTransaction>
    {
        private readonly ICategoryTransactionRepository repository;

        public CategoryTransactionHandler(ICategoryTransactionRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(CreateCategoryTransaction message)
        {
            this.repository.Create(new CategoryTransaction() { CategoryId = message.CategoryId, TransactionId = message.TransactionId });
            this.repository.Save();
        }

        public void Handle(RemoveCategoryTransaction message)
        {
            this.repository.Remove(message.TransactionId, message.CategoryId);
            this.repository.Save();
        }
    }
}
