using Fio.Downloader.DataAccess;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
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

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConnectionStrings.json");

            var configuration = builder.Build();

            using (var connection = new SqlConnection(configuration["db:dev"]))
            {
                var accountRepository = new AccountRepository(connection);
                var transactionRepository = new TransactionRepository(connection);
                var syncService = new SyncService(accountRepository, transactionRepository);

                await syncService.Sync();
            }
        }
    }
}