using System;

namespace Gnome.Core.Model.Database
{
    public class CategoryTransaction
    {
        public Guid CategoryId { get; set; }
        public Guid TransactionId { get; set; }
        public Category Category { get; set; }
        public Transaction Transaction { get; set; }
    }
}