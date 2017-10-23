using Gnome.Api.Services.CategoryTransactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.CategoryTransactions
{
    class CategoryTransactionDataHandler :
        IRequestHandler<CreateCategoryTransaction>,
        IRequestHandler<RemoveCategoryTransaction>
    {
        private readonly ITransactionRepository repository;

        public CategoryTransactionDataHandler(ITransactionRepository transactionRepository)
        {
            this.repository = transactionRepository;
        }

        public void Handle(CreateCategoryTransaction message)
        {
            var transaction = repository.Find(message.TransactionId);
            var categoryList = GetCategoryList(transaction);
            categoryList.Add(message.CategoryId);
            transaction.CategoryData = JsonConvert.SerializeObject(categoryList);
            repository.Save();
        }
        public void Handle(RemoveCategoryTransaction message)
        {
            var transaction = repository.Find(message.TransactionId);
            var categoryList = GetCategoryList(transaction);
            categoryList.Remove(message.CategoryId);
            transaction.CategoryData = JsonConvert.SerializeObject(categoryList);
            repository.Save();
        }

        private List<Guid> GetCategoryList(Transaction transaction)
        {
            return JsonConvert.DeserializeObject<List<Guid>>(transaction.CategoryData);
        }
    }
}