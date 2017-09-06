using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax.Factories
{
    public class BooleanOperatorFactory
    {
        public ISyntaxNode<bool> Build(IOperator value, IEnumerable<ISyntaxNode<bool>> children)
        {
            switch (value.Value)
            {
                case "and":
                    return new And(children.ToArray());
                case "or":
                    return new Or(children.ToArray());
                default:
                    throw new ArgumentException();
            }
        }
    }
}
