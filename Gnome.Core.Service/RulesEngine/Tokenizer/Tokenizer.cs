using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class Tokenizer
    {
        bool lookForSpace = true;
        bool lookForApostrophe = false;

        public List<IToken> Tokenize(string stringExpression)
        {
            var tokens = new List<IToken>();

            //"comment contains 'hello world'"
            var trimmed = stringExpression.Trim();

            int fromIndex = 0;
            int toIndex = GetIndexOfNextToken(fromIndex, trimmed);
            tokens.Add(GetToken(trimmed.Substring(fromIndex, toIndex - fromIndex)));
            return tokens;
        }

        private IToken GetToken(string v)
        {
            throw new NotImplementedException();
        }

        private int GetIndexOfNextToken(int fromIndex, string stringExpression)
        {
            if (lookForSpace)
                return stringExpression.IndexOf(' ', fromIndex);
            if (lookForApostrophe)
                return GetNextIndexOfApostrophe(fromIndex, stringExpression);
            throw new Exception("parsing exception");
        }

        private int GetNextIndexOfApostrophe(int fromIndex, string expression)
        {
            var next = expression.IndexOf('\'', fromIndex);
            if (expression.Length > next && expression[next + 1] == '\'')
                return GetNextIndexOfApostrophe(next + 1, expression);
            return next;
        }
    }
}