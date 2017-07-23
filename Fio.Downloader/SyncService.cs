using Fio.Core;
using Fio.Downloader.DataAccess;
using Fio.Downloader.Model;
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
                .Where(a => ShouldSync(a));

            foreach (var account in accounts)
            {
                var client = new FioClient(account.Token);

                //await client.SetStopFlag(DateTime.UtcNow.AddDays(-300));
                //var transactions = await client.Get(DateTime.Now.AddDays(-100), DateTime.Now);
                var transactions = await client.GetNew();

                await transactionRepository.SaveAll(account.Id, transactions.AccountStatement.TransactionList.Transactions);
                accountRepository.SetSyncDate(account.Id, DateTime.Now);
            }
        }

        private bool ShouldSync(Account a)
        {
            if (string.IsNullOrWhiteSpace(a.Token))
                return false;

            return a.LastSync.HasValue == false || ((DateTime.Now - a.LastSync.Value) > TimeSpan.FromHours(2));
        }
    }
}