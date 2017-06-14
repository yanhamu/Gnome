using System.Collections.Generic;

namespace Gnome.Web.Model.ViewModel
{
    public class Transaction
    {
        public int AccountId { get; set; }
        public Dictionary<string, string> Fields { get; set; }

        public Transaction()
        {
            Fields = new Dictionary<string, string>();
        }
    }
}
