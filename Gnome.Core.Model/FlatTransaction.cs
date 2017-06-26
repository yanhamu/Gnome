using System.Collections.Generic;

namespace Gnome.Core.Model
{
    public class FlatTransaction
    {
        public int AccountId { get; set; }
        public Dictionary<string, string> Fields { get; set; }

        public FlatTransaction()
        {
            Fields = new Dictionary<string, string>();
        }
    }
}
