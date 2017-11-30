using Fio.Downloader.DataAccess;
using Gnome.Database;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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
                .AddJsonFile("config.json")
                .Build();
            var baseApiUrl = configuration["app-api:base-url"];
            var transactionUrl = configuration["app-api:transactions"];

            using (var accountConnection = new SqliteConnection(configuration["db:core"]))
            using (var transactionConnection = new SqliteConnection(configuration["db:fio"]))
            using (var httpClient = new HttpClient())
            {
                accountConnection.Open();
                transactionConnection.Open();
                var initializer = new Initializer(transactionConnection, new List<string>() { "transaction" });
                if (initializer.HasAllTables() == false)
                    initializer.DropAndCreate();

                httpClient.BaseAddress = new System.Uri(baseApiUrl);
                var accountRepository = new AccountRepository(accountConnection);
                var transactionApiClient = new TransactionApiClient(httpClient, transactionUrl);
                var transactionRepository = new TransactionRepository(transactionConnection, transactionApiClient);
                var syncService = new SyncService(accountRepository, transactionRepository);

                await syncService.Sync();
            }
        }
    }
}