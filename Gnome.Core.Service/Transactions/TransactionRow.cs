using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Transactions
{
    public class TransactionRow
    {
        public TransactionRow(Guid id, Guid accountId, DateTime date, decimal amount, string type)
        {
            this.Id = id;
            this.Date = date;
            this.Amount = amount;
            this.Type = type;
            this.AccountId = accountId;
        }

        public Guid Id { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }
        public string Type { get; }
        public Guid AccountId { get; }

        public Dictionary<string, string> Fields { get; } = new Dictionary<string, string>();

        public string this[string field]
        {
            get
            {
                switch (field)
                {
                    case "id":
                        return this.Id.ToString();
                    case "date":
                        return this.Date.Date.ToString();
                    case "amount":
                        return this.Amount.ToString();
                    case "type":
                        return this.Type;
                    case "accountId":
                        return this.AccountId.ToString();
                    default:
                        return Fields.ContainsKey(field)
                            ? Fields[field]
                            : null;
                }
            }
            set
            {
                if (keywords.Contains(field))
                    throw new ArgumentException("cannot set that kind of field. Use property instead");

                Fields[field] = value;
            }
        }

        private List<string> keywords = new List<string>() { "id", "date", "amount", "type", "accountId" };
    }
}
