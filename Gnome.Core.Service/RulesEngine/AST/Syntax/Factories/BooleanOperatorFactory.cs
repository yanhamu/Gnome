using System;
using System.Collections.Generic;
using Gnome.Core.Service.RulesEngine.Tokenizer;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax.Factories
{
    public class BooleanOperatorFactory
    {
        internal ISyntaxNode<bool> Build(IOperator value, IEnumerable<ISyntaxNode<bool>> children)
        {
            throw new NotImplementedException();
        }
    }
}
