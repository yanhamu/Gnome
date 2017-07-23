using System;
using System.Collections.Generic;
using System.Text;

namespace Gnome.Core.Service.Transactions
{
    public class TransactionRow
    {
        public TransactionRow(Guid id, DateTime date, decimal amount, string type)
        {
            this.Id = id;
            this.Date = date;
            this.Amount = amount;
            this.Type = type;
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }

        private Dictionary<string, string> fields = new Dictionary<string, string>();

        public string this[string field]
        {
            get
            {
                if (field == "id")
                    return this.Id.ToString();
                if (field == "date")
                    return this.Date.Date.ToString();
                if (field == "amount")
                    return this.Amount.ToString();
                if (field == "type")
                    return this.Type;

                return fields.ContainsKey(field)
                    ? fields[field]
                    : null;
            }

            set
            {
                if (keywords.Contains(field))
                    throw new ArgumentException("cannot set that kind of field. Use property instead");

                fields[field] = value;
            }
        }

        private List<string> keywords = new List<string>() { "id", "date", "amount", "type" };
    }
}
