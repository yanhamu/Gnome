using Fio.Core.Model;
using Fio.Downloader.Model;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fio.Downloader.DataAccess
{
    public class TransactionRepository
    {
        private readonly SqliteConnection connection;
        private readonly ITransactionRepository transactionClient;

        public TransactionRepository(SqliteConnection connection, ITransactionRepository transactionClient)
        {
            this.connection = connection;
            this.transactionClient = transactionClient;
        }

        public async Task SaveAll(Guid accountId, List<Transaction> transactions)
        {
            foreach (var t in transactions)
            {
                var fioTransaction = Convert(Convert(accountId, t));
                try
                {
                    await transactionClient.SaveTransaction(fioTransaction);
                }
                catch (System.Exception ex)
                {
                    //TODO log!
                }
            }
        }

        private FioTransaction Convert(Guid accountId, Transaction t)
        {
            return new FioTransaction()
            {
                Accountant = t.Accountant?.Value,
                AccountId = accountId,
                Amount = t.Amount.Value,
                Bic = t.Bic?.Value,
                Comment = t.Comment?.Value,
                ConstantSymbol = t.ConstantSymbol?.Value,
                CounterpartAccount = t.CounterpartAccount?.Value,
                CounterpartAccountName = t.CounterpartAccountName?.Value,
                CounterpartBankCode = t.CounterpartBankCode?.Value,
                CounterpartBankName = t.CounterpartBankName?.Value,
                Currency = t.Currency.Value,
                Date = t.Date.Value,
                FioId = t.Id.Value,
                Identification = t.Identification?.Value,
                InstructionId = t.InstructionId.Value,
                MessageForReceipient = t.MessageForReceipient?.Value,
                SpefificSymbol = t.SpefificSymbol?.Value,
                Type = t.Type?.Value,
                VariableSymbol = t.VariableSymbol?.Value
            };
        }

        public Gnome.Core.Model.Transaction Convert(FioTransaction fio)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new TransactionContractResolver();

            var data = JsonConvert.SerializeObject(fio, Formatting.None, settings);

            return new Gnome.Core.Model.Transaction()
            {
                AccountId = fio.AccountId,
                Amount = fio.Amount,
                Date = fio.Date,
                Type = "fio",
                Data = data
            };
        }

        public class TransactionContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }

            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var properties = base.CreateProperties(type, memberSerialization);
                var propertiesToIgnore = typeof(Gnome.Core.Model.Transaction).GetProperties().Select(p => p.Name.ToLower()).ToList();
                return properties.Where(p => !propertiesToIgnore.Contains(p.PropertyName)).ToList();
            }
        }
    }
}