using System;

namespace Gnome.Core.Model
{
    public class Expression
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ExpressionString { get; set; }
        public User User { get; set; }
    }
}