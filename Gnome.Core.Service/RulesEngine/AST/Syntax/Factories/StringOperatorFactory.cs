using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax.Factories
{
    public class StringOperatorFactory
    {
        public ISyntaxNode<bool> Build(IOperator value, IEnumerable<IToken> enumerable)
        {
            var nodes = new List<ISyntaxNode<string>>();
            foreach (var token in enumerable)
                nodes.Add(GetNode(token));
            return GetBoolNode(value, nodes.ToArray());
        }

        private ISyntaxNode<bool> GetBoolNode(IOperator value, ISyntaxNode<string>[] syntaxNode)
        {
            switch (value.Value)
            {
                case "=":
                    return new StringEquals(syntaxNode);
                case "!=":
                    return new StringNotEqual(syntaxNode);
                default:
                    throw new ArgumentException();
            }
        }

        private ISyntaxNode<string> GetNode(IToken token)
        {
            if (token is StringToken)
                return new String(token.Value);
            if (token is FieldToken)
                return new StringField(token.Value);

            throw new ArgumentException("Unexpected token received");
        }
    }
}