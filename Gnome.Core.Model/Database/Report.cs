using System;

namespace Gnome.Core.Model.Database
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid QueryId { get; set; }
        public Query Query { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
    }
}
