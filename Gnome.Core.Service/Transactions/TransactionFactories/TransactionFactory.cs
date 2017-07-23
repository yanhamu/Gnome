using Gnome.Core.Model;
using Newtonsoft.Json;
using System;

namespace Gnome.Core.Service.Transactions.TransactionFactories
{
    public class TransactionFactory : ITransactionFactory<FioTransaction>
    {
        private readonly JsonSerializerSettings settings;

        public TransactionFactory()
        {
            this.settings = new JsonSerializerSettings();
            settings.ContractResolver = new TransactionContractResolver();
        }

        public Transaction Create(FioTransaction fioTransaction)
        {
            var data = JsonConvert.SerializeObject(fioTransaction, Formatting.None, settings);

            return new Transaction()
            {
                Id = Guid.NewGuid(),
                AccountId = fioTransaction.AccountId,
                Amount = fioTransaction.Amount,
                Date = fioTransaction.Date.Date,
                Type = "fio",
                Data = data
            };
        }
    }
}
