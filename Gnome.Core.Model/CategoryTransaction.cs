﻿using System;

namespace Gnome.Core.Model
{
    public class CategoryTransaction
    {
        public int CategoryId { get; set; }
        public Guid TransactionId { get; set; }
        public Category Category { get; set; }
        public Transaction Transaction { get; set; }
    }
}