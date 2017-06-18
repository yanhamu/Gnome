using Fio.Core;
using System;

namespace Fio.Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("fio downloader");

            var accountId = 123;
            var token = "XXX";
            var client = new FioClient(token);
            var transactions = client.Get(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(-50));

            var transactionRepository = new TransactionRepository(accountId);
            transactionRepository.SaveAll(transactions);

            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}