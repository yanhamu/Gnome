using Fio.Core.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fio.Core
{
    public class FioClient
    {
        private readonly string token;

        public FioClient(string token)
        {
            this.token = token;
        }

        public async Task<Transactions> Get(DateTime from, DateTime to)
        {
            var formattedFrom = from.ToString("yyyy-MM-dd");
            var formattedTo = to.ToString("yyyy-MM-dd");

            var url = $"https://www.fio.cz/ib_api/rest/periods/{token}/{formattedFrom}/{formattedTo}/transactions.json";

            var response = await DownloadContent(url);
            return JsonConvert.DeserializeObject<Transactions>(response);
        }

        public async Task SetStopFlag(DateTime lastDate)
        {
            var formattedDate = lastDate.ToString("yyyy-MM-dd");
            var url = $"https://www.fio.cz/ib_api/rest/set-last-date/{token}/{formattedDate}/";
            var response = await DownloadContent(url);
        }

        public async Task<Transactions> GetNew()
        {
            var url = $"https://www.fio.cz/ib_api/rest/last/{token}/transactions.json";
            var response = await DownloadContent(url);
            return JsonConvert.DeserializeObject<Transactions>(response);
        }

        private async Task<string> DownloadContent(string url)
        {
            using (var httpClient = new HttpClient())
                return await httpClient.GetStringAsync(url);
        }
    }
}