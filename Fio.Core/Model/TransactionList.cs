using Newtonsoft.Json;
using System.Collections.Generic;

namespace Fio.Core.Model
{
    public class TransactionList
    {
        [JsonProperty(PropertyName = "transaction")]
        public List<Transaction> Transactions { get; set; }

        public override string ToString()
        {
            return Transactions == null ? "---" : Transactions.Count + " transactions";
        }
    }
}
