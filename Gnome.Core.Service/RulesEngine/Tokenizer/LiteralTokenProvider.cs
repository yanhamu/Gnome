﻿using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class LiteralTokenProvider : ITokenProvider
    {
        private readonly HashSet<string> operatorKeywords;
        private readonly HashSet<char> stopCharacters;

        public LiteralTokenProvider(HashSet<string> operatorKeywords, HashSet<char> stopCharacters)
        {
            this.operatorKeywords = operatorKeywords;
            this.stopCharacters = stopCharacters;
        }

        public TokenProviderResult GetToken(int startIndex, string expression)
        {
            if (expression[startIndex] == ' ' || expression[startIndex] == '\'')
                throw new ArgumentException($"Invalid beginning in {expression} at {startIndex}");

            var index = startIndex + 1;
            while (expression.Length > index)
            {
                if (stopCharacters.Contains(expression[index]))
                {
                    break;
                }

                index += 1;
            }

            var token = GetToken(expression, startIndex, index - startIndex);

            return new TokenProviderResult(startIndex, index - 1, token);
        }

        private IToken GetToken(string expression, int startIndex, int charcount)
        {
            var value = expression.Substring(startIndex, charcount);
            return operatorKeywords.Contains(value)
                ? (IToken)new OperatorToken(value)
                : (IToken)new FieldToken(value);
        }
    }
}