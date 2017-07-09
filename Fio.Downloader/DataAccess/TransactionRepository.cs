using Dapper;
using Fio.Core.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        public void SaveAll(int accountId, List<Transaction> transactions)
        {
            foreach (var t in transactions)
            {
                try
                {
                    transactionClient.SaveTransaction(accountId, t);
                }
                catch (System.Exception ex)
                {
                    //TODO log!
                    SaveTransaction(accountId, t);
                }
            }
        }

        public void SaveTransaction(int accountId, Transaction t)
        {
            var id = connection.Execute(sql, new
            {
                @accountId = accountId,
                @fioId = t.Id.Value,
                @date = t.Date.Value,
                @amount = t.Amount.Value,
                @currency = t.Currency.Value,
                @counterAccount = t.CounterpartAccount?.Value,
                @counterAccountName = t.CounterpartAccountName?.Value,
                @counterBankCode = t.CounterpartBankCode?.Value,
                @counterBankName = t.CounterpartBankName?.Value,
                @constantSymbol = t.ConstantSymbol?.Value,
                @variableSymbol = t.VariableSymbol?.Value,
                @specificSymbol = t.SpefificSymbol?.Value,
                @identification = t.Identification?.Value,
                @message = t.MessageForReceipient?.Value,
                @type = t.Type.Value,
                @accountant = t.Accountant?.Value,
                @comment = t.Comment?.Value,
                @bankIdentificationNumber = t.Bic?.Value,
                @instructionId = t.InstructionId?.Value
            });
        }
    }
}