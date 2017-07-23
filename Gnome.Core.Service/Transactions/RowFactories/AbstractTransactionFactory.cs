using Gnome.Core.Model;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Transactions.RowFactories
{
    public interface IAbstractTransactionFactory
    {
        TransactionRow Create(Transaction transaction);
    }

    public class AbstractTransactionFactory : IAbstractTransactionFactory
    {
        private TransactionTemplate fioTemplate = new TransactionTemplate(new List<string> { });

        public TransactionRow Create(Transaction transaction)
        {
            if (transaction.Type == "fio")
                return new TransactionFactory(fioTemplate).Create(transaction);

            throw new ArgumentException($"Transaction type {transaction.Type} is not supported");
        }
    }
}