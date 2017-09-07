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

            return GetBoolNode(value, nodes.ToArray());
        }

        private ISyntaxNode<bool> GetBoolNode(IOperator value, ISyntaxNode<decimal>[] children)
        {
            switch (value.Value)
            {
                case "=":
                    return new NumberEqual(children);
                case "!=":
                    return new NumberNotEqual(children);
                case "<":
                    return new NumberLess(children);
                case ">":
                    return new NumberMore(children);
                case ">=":
                    return new NumberMoreOrEqual(children);
                case "<=":
                    return new NumberLessOrEqual(children);
                default:
                    throw new ArgumentException();
            }
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
