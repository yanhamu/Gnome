using Fio.Core;
using Fio.Downloader.DataAccess;
using System;
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
            var now = DateTime.Now;
            var accounts = accountRepository.GetAccountsToSync();
            foreach (var account in accounts)
            {
                var lastSync = account.LastSync;
                if (lastSync.HasValue && (now - lastSync) < TimeSpan.FromHours(2))
                    continue;

                var client = new FioClient(account.Token);
                var transactions = await client.Get(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(-50));

                transactionRepository.SaveAll(account.Id, transactions.AccountStatement.TransactionList.Transactions);
                accountRepository.SetSyncDate(account.Id, now);
            }
        }
    }
}