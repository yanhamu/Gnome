using System;

namespace Gnome.Core.Model.Database
{
    public class Rule
    {
        public Guid Id { get; set; }
        public Guid ExpressionId { get; set; }
        public Expression Expression { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string ActionType { get; set; }
        public string ActionData { get; set; }
    }
}
