using Dapper;
using Fio.Core;
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
            var token = GetToken(accountId);
            var client = new FioClient(token);
            var transactions = await client.Get(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(-50));


            using (var connection = new SqlConnection(SqlConnectionString))
            {
                var transactionRepository = new TransactionRepository(connection);
                transactionRepository.SaveAll(accountId, transactions.AccountStatement.TransactionList.Transactions);
            }
        }

        public const string SqlConnectionString = "Data Source=TOM-LENOVO\\SQLEXPRESS;Initial Catalog=gnome;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static string GetToken(int accountId)
        {
            using (var connection = new SqlConnection(SqlConnectionString))
            {
                var sql = "select token from fio_account where id = @id";
                return connection.QueryFirst<string>(sql, new { id = accountId });
            }
        }
    }
}