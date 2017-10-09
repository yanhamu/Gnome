using System;

namespace Gnome.Api.Services.Reports
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid QueryId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Report(Guid id, Guid queryId, string name, string type)
        {
            this.Id = id;
            this.QueryId = queryId;
            this.Name = name;
            this.Type = type;
        }
    }
}
