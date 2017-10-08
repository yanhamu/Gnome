using Fio.Core;
using Fio.Downloader.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fio.Downloader
{
    public class SyncService
    {
        private AccountRepository accountRepository;
        private TransactionRepository transactionRepository;

        public SyncService(AccountRepository accountRepository, TransactionRepository transactionRepository)
        {
            this.accountRepository = accountRepository;
            this.transactionRepository = transactionRepository;
        }

        public async Task Sync()
        {
            var accounts = accountRepository
                .GetAccountsToSync()
                .ToList()
                .Where(a => string.IsNullOrWhiteSpace(a.Token) == false)
                .ToList();

            foreach (var account in accounts)
            {
                var client = new FioClient(account.Token);

                var transactions = await client.Get(DateTime.Now.AddYears(-1), DateTime.UtcNow);
                //var transactions = await client.GetNew();

                await transactionRepository.SaveAll(account.Id, transactions.AccountStatement.TransactionList.Transactions);
            }
        }
    }
}