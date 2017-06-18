using Fio.Downloader.DataAccess;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Fio.Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("fio downloader");

            var accountId = 1;

            Task.Run(() => Run(accountId)).GetAwaiter().GetResult();

            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        private static async Task Run(int accountId)
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