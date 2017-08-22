using Gnome.Core.Service.RulesEngine.AST.Syntax;
using Gnome.Core.Service.RulesEngine.AST.Syntax.Factories;
using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class SyntaxTreeBuilder
    {
        public ISyntaxNode<bool> Build(Node<IToken> node)
        {
            if (node.Children.All(c => c.Value is IOperand))
            {
                return MakeBooleanSyntaxNode((IOperator)node.Value, node.Children.Select(c => c.Value));
            }
            else if (node.Children.All(c => c.Value is IOperator))
            {
                return MakeBooleanSyntaxNode((IOperator)node.Value, node.Children.Select(c => Build(c)));
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private ISyntaxNode<bool> MakeBooleanSyntaxNode(IOperator value, IEnumerable<ISyntaxNode<bool>> children)
        {
            return new BooleanOperatorFactory().Build(value, children);
        }

        private ISyntaxNode<bool> MakeBooleanSyntaxNode(IOperator value, IEnumerable<IToken> children)
        {
            if (children.Any(e => e is StringToken) && children.Any(e => e is NumberToken)) // type exception
                throw new ArgumentException("type exception");

            if (children.Any(e => e is StringToken))
            {
                return new StringOperatorFactory().Build(value, children);
            }
            else if (children.Any(e => e is NumberToken))
            {
                return new NumberOperatorFactory().Build(value, children);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}