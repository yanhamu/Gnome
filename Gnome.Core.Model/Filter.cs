using Gnome.Core.Model.Database;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Model
{
    public class Filter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public List<Expression> Included { get; set; }
        public List<Expression> Excluded { get; set; }
        public List<Guid> Accounts { get; set; }
    }
}
