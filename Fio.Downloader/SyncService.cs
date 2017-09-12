using Fio.Core;
using Fio.Downloader.DataAccess;
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
                .Where(a => string.IsNullOrWhiteSpace(a.Token) == false);

            foreach (var account in accounts)
            {
                var client = new FioClient(account.Token);

                //await client.SetStopFlag(DateTime.UtcNow.AddDays(-300));
                //var transactions = await client.Get(System.DateTime.Now.AddDays(-100), System.DateTime.Now);
                var transactions = await client.GetNew();

                await transactionRepository.SaveAll(account.Id, transactions.AccountStatement.TransactionList.Transactions);
            }
        }
    }
}