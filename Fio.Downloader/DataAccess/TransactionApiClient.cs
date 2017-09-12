using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fio.Downloader.DataAccess
{
    public class TransactionApiClient : ITransactionRepository
    {
        private readonly HttpClient httpClient;
        private readonly string uri;

        public TransactionApiClient(HttpClient httpClient, string uri)
        {
            this.httpClient = httpClient;
            this.uri = uri;
        }

        public async Task SaveTransaction(Gnome.Core.Model.Transaction transaction)
        {
            var json = JsonConvert.SerializeObject(transaction);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, content);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Server didn't accept transaction");
        }
    }
}