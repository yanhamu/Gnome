using Gnome.Api.Services.CategoryTransactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.CategoryTransactions
{
    public class CategoryTransactionDataHandler :
        INotificationHandler<CreateCategoryTransaction>,
        INotificationHandler<RemoveCategoryTransaction>
    {
        private readonly ITransactionRepository repository;

        public CategoryTransactionDataHandler(ITransactionRepository transactionRepository)
        {
            this.repository = transactionRepository;
        }

        public async Task Handle(CreateCategoryTransaction message, CancellationToken cancellationToken)
        {
            var transaction = await repository.Find(message.TransactionId);
            var categoryList = GetCategoryList(transaction);
            categoryList.Add(message.CategoryId);
            transaction.CategoryData = JsonConvert.SerializeObject(categoryList);
            await repository.Save();
        }

        public async Task Handle(RemoveCategoryTransaction message, CancellationToken cancellationToken)
        {
            var transaction = await repository.Find(message.TransactionId);
            var categoryList = GetCategoryList(transaction);
            categoryList.Remove(message.CategoryId);
            transaction.CategoryData = JsonConvert.SerializeObject(categoryList);
            await repository.Save();
        }

        private List<Guid> GetCategoryList(Transaction transaction)
        {
            return JsonConvert.DeserializeObject<List<Guid>>(transaction.CategoryData);
        }
    }
}