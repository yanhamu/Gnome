using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class ParseTreeBuilder
    {
        private readonly ExpressionFactory expressionFactory;

        public ParseTreeBuilder(ExpressionFactory expressionFactory)
        {
            this.expressionFactory = expressionFactory;
        }

        public Node Build(List<IToken> tokens)
        {
            var filtered = tokens.Where(t => !(t is SkipToken)).ToList();
            var addParentheses = AddParentheses(filtered);
            var index = 0;
            var root = new Node(null);
            var pointer = root;
            do
            {
                var current = tokens[index];

                if (current is OpenParenthesisToken)
                {
                    pointer.LeftChild = new Node(pointer);
                    pointer = pointer.LeftChild;
                }
                else if (IsOperator(current))
                {
                    pointer.Token = current;
                    pointer.RightChild = new Node(pointer);
                    pointer = pointer.RightChild;
                }
                else if (IsOperand(current))
                {
                    pointer.Token = current;
                    pointer = pointer.Parent;
                }
                else if (current is ClosingParenthesisToken)
                {
                    pointer = pointer.Parent;
                }
                index += 1;
            } while (pointer.Parent != null);

            return root;
        }

        private List<IToken> AddParentheses(List<IToken> tokens)
        {
            throw new NotImplementedException();
        }

        private bool IsOperator(IToken token)
        {
            return token is NumberToken || token is FieldToken || token is StringToken;
        }

        private bool IsOperand(IToken token)
        {
            return token is OperatorToken;
        }
    }
}
