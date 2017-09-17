using Gnome.Core.Model.Database;
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
        private TransactionTemplate fioTemplate = new TransactionTemplate(new List<string> { "fioid", "currency", "counterpartaccount", "counterpartaccountname", "counterpartbankcode", "counterpartbankname", "constantsymbol", "variablesymbol", "spefificsymbol", "identification", "messageforreceipient", "accountant", "comment", "bic", "instructionid" }, "fio");

        public TransactionRow Create(Transaction transaction)
        {
            if (transaction.Type == "fio")
                return new TransactionFactory(fioTemplate).Create(transaction);

            throw new ArgumentException($"Transaction type {transaction.Type} is not supported");
        }
    }
}