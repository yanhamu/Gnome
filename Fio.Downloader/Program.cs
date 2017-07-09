using Fio.Downloader.DataAccess;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
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
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConnectionStrings.json")
                .AddJsonFile("config.json")
                .Build();

            var baseApiUrl = configuration["app-api:base-url"];
            var transactionUrl = configuration["app-api:transactions"];

            using (var connection = new SqlConnection(configuration["db:dev"]))
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri(baseApiUrl);
                var accountRepository = new AccountRepository(connection);
                var transactionApiClient = new TransactionApiClient(httpClient, transactionUrl);
                var transactionRepository = new TransactionRepository(connection, transactionApiClient);
                var syncService = new SyncService(accountRepository, transactionRepository);

                await syncService.Sync();
            }
        }
    }
}