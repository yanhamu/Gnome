using Fio.Core.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fio.Downloader.DataAccess
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly SqliteConnection connection;
        private readonly ITransactionRepository transactionClient;

        private const string sql = "insert into fio_transaction values(@accountId, @fioId, @date, @amount, @currency, @counterAccount, @counterAccountName, @counterBankCode, @counterBankName, @constantSymbol, @variableSymbol, @specificSymbol, @identification, @message, @type, @accountant, @comment, @bankIdentificationNumber, @instructionId)";

        public TransactionRepository(SqliteConnection connection, ITransactionRepository transactionClient)
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
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.Add(new SqliteParameter("accountId", t.AccountId));
                command.Parameters.Add(new SqliteParameter("@fioId", t.FioId));
                command.Parameters.Add(new SqliteParameter("@date", t.Date));
                command.Parameters.Add(new SqliteParameter("@amount", t.Amount));
                command.Parameters.Add(new SqliteParameter("@currency", t.Currency));
                command.Parameters.Add(new SqliteParameter("@counterAccount", t.CounterpartAccount));
                command.Parameters.Add(new SqliteParameter("@counterAccountName", t.CounterpartAccountName));
                command.Parameters.Add(new SqliteParameter("@counterBankCode", t.CounterpartBankCode));
                command.Parameters.Add(new SqliteParameter("@counterBankName", t.CounterpartBankName));
                command.Parameters.Add(new SqliteParameter("@constantSymbol", t.ConstantSymbol));
                command.Parameters.Add(new SqliteParameter("@variableSymbol", t.VariableSymbol));
                command.Parameters.Add(new SqliteParameter("@specificSymbol", t.SpefificSymbol));
                command.Parameters.Add(new SqliteParameter("@identification", t.Identification));
                command.Parameters.Add(new SqliteParameter("@message", t.MessageForReceipient));
                command.Parameters.Add(new SqliteParameter("@type", t.Type));
                command.Parameters.Add(new SqliteParameter("@accountant", t.Accountant));
                command.Parameters.Add(new SqliteParameter("@comment", t.Comment));
                command.Parameters.Add(new SqliteParameter("@bankIdentificationNumber", t.Bic));
                command.Parameters.Add(new SqliteParameter("@instructionId", t.InstructionId));

                await command.ExecuteNonQueryAsync();
            }
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