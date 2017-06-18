using Newtonsoft.Json;

namespace Fio.Core.Model
{
    public class Transactions
    {
        [JsonProperty(PropertyName = "accountStatement")]
        public AccountStatement AccountStatement { get; set; }
    }
}
