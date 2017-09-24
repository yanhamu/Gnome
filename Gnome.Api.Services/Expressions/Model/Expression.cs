using System;

namespace Gnome.Api.Services.Expressions.Model
{
    public class Expression
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ExpressionString { get; set; }
    }
}
