using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax.Factories
{
    public class NumberOperatorFactory
    {
        public ISyntaxNode<bool> Build(IOperator value, IEnumerable<IToken> enumerable)
        {
            var nodes = new List<ISyntaxNode<decimal>>();
            foreach (var token in enumerable)
                nodes.Add(GetNode(token));

            return new NumberEquals(nodes.ToArray());
        }

        private ISyntaxNode<decimal> GetNode(IToken token)
        {
            if (token is NumberToken)
                return new Number(decimal.Parse(token.Value));
            if (token is FieldToken)
                return new NumberField(token.Value);

            throw new ArgumentException("Unexpected token received");
        }
    }
}
