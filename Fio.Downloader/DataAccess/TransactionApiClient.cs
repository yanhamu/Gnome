using Fio.Core.Model;
using System;

namespace Fio.Downloader.DataAccess
{
    public class TransactionApiClient : ITransactionRepository
    {
        public void SaveTransaction(int accountId, Transaction transaction)
        {
            var fionTransaction = Convert(accountId, transaction);

            throw new NotImplementedException();
        }

        private Gnome.Core.Model.FioTransaction Convert(int accountId, Transaction t)
        {
            return new Gnome.Core.Model.FioTransaction()
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
    }
}
