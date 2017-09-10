using System;

namespace Gnome.Core.Model
{
    public class Filter
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Expression { get; set; }
        public User User { get; set; }
    }
}
