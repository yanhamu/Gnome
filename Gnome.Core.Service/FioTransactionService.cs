using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service
{
    public class FioTransactionService : ITransactionService
    {
        private readonly IFioTransactionRepository repository;

        public FioTransactionService(IFioTransactionRepository repository)
        {
            this.repository = repository;
        }

        public List<FlatTransaction> GetTransactions(int accountId, int limit)
        {
            var tr = repository.Retrieve(accountId, limit);

            return repository
                .Retrieve(accountId, limit)
                .OrderByDescending(t => t.Date)
                .Select(t => Flattern(t))
                .ToList();
        }

        private FlatTransaction Flattern(FioTransaction t)
        {
            var flat = new FlatTransaction()
            {
                AccountId = t.AccountId
            };

            flat.Fields.Add(nameof(t.Accountant), t.Accountant);
            flat.Fields.Add(nameof(t.AccountId), t.AccountId.ToString());
            flat.Fields.Add(nameof(t.Amount), t.Amount.ToString());
            flat.Fields.Add(nameof(t.Bic), NullableToString(t.Bic));
            flat.Fields.Add(nameof(t.Comment), NullableToString(t.Comment));
            flat.Fields.Add(nameof(t.ConstantSymbol), NullableToString(t.ConstantSymbol));
            flat.Fields.Add(nameof(t.CounterpartAccount), NullableToString(t.CounterpartAccount));
            flat.Fields.Add(nameof(t.CounterpartAccountName), NullableToString(t.CounterpartAccountName));
            flat.Fields.Add(nameof(t.CounterpartBankCode), NullableToString(t.CounterpartBankCode));
            flat.Fields.Add(nameof(t.CounterpartBankName), NullableToString(t.CounterpartBankName));
            flat.Fields.Add(nameof(t.Currency), NullableToString(t.Currency));
            flat.Fields.Add(nameof(t.Date), t.Date.ToString());
            flat.Fields.Add(nameof(t.FioId), t.FioId.ToString());
            flat.Fields.Add(nameof(t.Id), t.Id.ToString());
            flat.Fields.Add(nameof(t.Identification), NullableToString(t.Identification));
            flat.Fields.Add(nameof(t.InstructionId), t.InstructionId.ToString());
            flat.Fields.Add(nameof(t.MessageForReceipient), NullableToString(t.MessageForReceipient));
            flat.Fields.Add(nameof(t.SpefificSymbol), NullableToString(t.SpefificSymbol));
            flat.Fields.Add(nameof(t.Type), NullableToString(t.Type));
            flat.Fields.Add(nameof(t.VariableSymbol), NullableToString(t.VariableSymbol));

            return flat;
        }

        private string NullableToString(string value)
        {
            return value == null
                ? string.Empty
                : value.ToString();
        }
    }
}
