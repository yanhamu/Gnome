using Fio.Downloader.DataAccess;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Fio.Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => Run()).GetAwaiter().GetResult();
        }

        private static async Task Run()
        {
            using (var connection = new SqlConnection(SqlConnectionString))
            {
                var accountRepository = new AccountRepository(connection);
                var transactionRepository = new TransactionRepository(connection);
                var syncService = new SyncService(accountRepository, transactionRepository);

                await syncService.Sync();
            }
        }

        public const string SqlConnectionString = "Data Source=TOM-LENOVO\\SQLEXPRESS;Initial Catalog=gnome;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}