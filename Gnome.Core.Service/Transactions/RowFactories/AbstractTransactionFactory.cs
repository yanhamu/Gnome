using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Transactions.RowFactories
{
    public class AbstractTransactionFactory
    {
        private TransactionTemplate fioTemplate = new TransactionTemplate(new List<string> { });

        public TransactionFactory Create(string type)
        {
            if (type == "fio")
                return new TransactionFactory(fioTemplate);
            throw new ArgumentException($"Transaction type {type} is not supported");
        }
    }
}