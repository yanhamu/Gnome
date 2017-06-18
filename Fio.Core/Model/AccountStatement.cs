using Newtonsoft.Json;

namespace Fio.Core.Model
{
    public class AccountStatement
    {
        [JsonProperty(PropertyName = "info")]
        public Info Info { get; set; }

        [JsonProperty(PropertyName = "transactionList")]
        public TransactionList TransactionList { get; set; }
    }
}