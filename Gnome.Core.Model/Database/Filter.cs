using System;

namespace Gnome.Core.Model.Database
{
    public class Filter
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
