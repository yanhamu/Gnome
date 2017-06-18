using Newtonsoft.Json;

namespace Fio.Core.Model
{
    public class Column<T>
    {
        [JsonProperty(PropertyName = "value")]
        public T Value { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
