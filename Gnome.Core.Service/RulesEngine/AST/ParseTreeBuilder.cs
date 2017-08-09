using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class ParseTreeBuilder
    {
        public Node Build(List<IToken> tokens)
        {
            var filtered = tokens.Where(t => !(t is SkipToken)).ToList();
            var index = 0;
            var root = new Node(null);
            var pointer = root;
            do
            {
                var current = filtered[index];

                if (current is OpenParenthesisToken)
                {
                    var node = new Node(pointer);
                    pointer.AddChild(node);

                    pointer = node;
                }
                else if (IsOperator(current))
                {
                    if (pointer.Token != null)
                    {
                        var node = new Node(null) { Token = current };
                        if (pointer.Parent == null)
                        {
                            pointer.Parent = node;
                            node.AddChild(pointer);

                            root = node;
                            pointer = node;
                        }
                        else
                        {
                            var parent = pointer.Parent;
                            pointer.Parent = node;
                            node.AddChild(pointer);

                            node.Parent = parent;
                            if (parent.Left == pointer)
                            {
                                parent.Left = node;
                            }
                            else
                            {
                                parent.Right = node;

                            }
                        }
                    }
                    else
                    {
                        pointer.Token = current;
                    }
                }
                else if (IsOperand(current))
                {
                    var node = new Node(pointer);
                    node.Token = current;
                    pointer.AddChild(node);
                }
                else if (current is ClosingParenthesisToken)
                {
                    pointer = pointer.Parent;
                }
                index += 1;
            } while (index < filtered.Count);

            return root;
        }

        private bool IsOperator(IToken token)
        {
            return token is OperatorToken;
        }

        private bool IsOperand(IToken token)
        {
            return token is NumberToken || token is FieldToken || token is StringToken;
        }
    }
}
