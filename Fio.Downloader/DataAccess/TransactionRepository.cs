using Dapper;
using Fio.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Fio.Downloader.DataAccess
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly SqlConnection connection;
        private readonly ITransactionRepository transactionClient;

        private const string sql = "insert into [fio].fio_transaction values(@accountId, @fioId, @date, @amount, @currency, @counterAccount, @counterAccountName, @counterBankCode, @counterBankName, @constantSymbol, @variableSymbol, @specificSymbol, @identification, @message, @type, @accountant, @comment, @bankIdentificationNumber, @instructionId)";

        public TransactionRepository(SqlConnection connection, ITransactionRepository transactionClient)
        {
            this.connection = connection;
            this.transactionClient = transactionClient;
        }

        public async Task SaveAll(Guid accountId, List<Transaction> transactions)
        {
            foreach (var t in transactions)
            {
                var fioTransaction = Convert(accountId, t);
                try
                {
                    await transactionClient.SaveTransaction(fioTransaction);
                }
                catch (System.Exception)
                {
                    //TODO log!
                    await SaveTransaction(fioTransaction);
                }
            }
        }

        public async Task SaveTransaction(Gnome.Core.Model.FioTransaction t)
        {
            var id = await connection.ExecuteAsync(sql, new
            {
                @accountId = t.AccountId,
                @fioId = t.FioId,
                @date = t.Date,
                @amount = t.Amount,
                @currency = t.Currency,
                @counterAccount = t.CounterpartAccount,
                @counterAccountName = t.CounterpartAccountName,
                @counterBankCode = t.CounterpartBankCode,
                @counterBankName = t.CounterpartBankName,
                @constantSymbol = t.ConstantSymbol,
                @variableSymbol = t.VariableSymbol,
                @specificSymbol = t.SpefificSymbol,
                @identification = t.Identification,
                @message = t.MessageForReceipient,
                @type = t.Type,
                @accountant = t.Accountant,
                @comment = t.Comment,
                @bankIdentificationNumber = t.Bic,
                @instructionId = t.InstructionId
            });
        }

        private Gnome.Core.Model.FioTransaction Convert(Guid accountId, Transaction t)
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