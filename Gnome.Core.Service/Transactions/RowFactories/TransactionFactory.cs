﻿using Gnome.Core.Model;
using Newtonsoft.Json.Linq;

namespace Gnome.Core.Service.Transactions.RowFactories
{
    public class TransactionFactory
    {
        private readonly TransactionTemplate template;

        public TransactionFactory(TransactionTemplate template)
        {
            this.template = template;
        }

        public TransactionRow Create(Transaction transaction)
        {
            var transactionRow = new TransactionRow(transaction.Id, transaction.Date.Date, transaction.Amount, transaction.Type);

            var jsonObject = JObject.Parse(transaction.Data);

            foreach (var field in template)
                transactionRow[field] = jsonObject[field]?.ToString();

            return transactionRow;
        }
    }
}