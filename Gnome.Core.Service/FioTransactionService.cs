using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service
{
    public class FioTransactionService : ITransactionService
    {
        private readonly FioTransactionRepository repository;

        public FioTransactionService(FioTransactionRepository repository)
        {
            this.repository = repository;
        }

        public List<FlatTransaction> GetTransactions(int accountId, int limit)
        {
            return repository
                .Retrieve(accountId, limit)
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
            flat.Fields.Add(nameof(t.Bic), t.Bic.ToString());
            flat.Fields.Add(nameof(t.Comment), t.Comment.ToString());
            flat.Fields.Add(nameof(t.ConstantSymbol), t.ConstantSymbol.ToString());
            flat.Fields.Add(nameof(t.CounterpartAccount), t.CounterpartAccount.ToString());
            flat.Fields.Add(nameof(t.CounterpartAccountName), t.CounterpartAccountName.ToString());
            flat.Fields.Add(nameof(t.CounterpartBankCode), t.CounterpartBankCode.ToString());
            flat.Fields.Add(nameof(t.CounterpartBankName), t.CounterpartBankName.ToString());
            flat.Fields.Add(nameof(t.Currency), t.Currency.ToString());
            flat.Fields.Add(nameof(t.Date), t.Date.ToString());
            flat.Fields.Add(nameof(t.FioId), t.FioId.ToString());
            flat.Fields.Add(nameof(t.Id), t.Id.ToString());
            flat.Fields.Add(nameof(t.Identification), t.Identification.ToString());
            flat.Fields.Add(nameof(t.InstructionId), t.InstructionId.ToString());
            flat.Fields.Add(nameof(t.MessageForReceipient), t.MessageForReceipient.ToString());
            flat.Fields.Add(nameof(t.SpefificSymbol), t.SpefificSymbol.ToString());
            flat.Fields.Add(nameof(t.Type), t.Type.ToString());
            flat.Fields.Add(nameof(t.VariableSymbol), t.VariableSymbol.ToString());


            return flat;
        }
    }
}
