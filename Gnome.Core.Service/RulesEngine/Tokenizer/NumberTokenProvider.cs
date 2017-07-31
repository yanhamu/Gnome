using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class NumberTokenProvider : ITokenProvider
    {
        private readonly HashSet<char> stopCharacters;

        public NumberTokenProvider(HashSet<char> stopCharacters)
        {
            this.stopCharacters = stopCharacters;
        }

        public TokenProviderResult GetToken(int startIndex, string expression)
        {
            if (!char.IsNumber(expression[startIndex]))
                throw new ArgumentException($"Invalid beginning in {expression} at {startIndex}");

            var index = startIndex + 1;
            while (expression.Length > index)
            {
                if (char.IsNumber(expression[index]))
                {
                    index += 1;
                    continue;
                }
                if (expression[index] == '.')
                {
                    index += 1;
                    continue;
                }
                if (stopCharacters.Contains(expression[index]))
                {
                    break;
                }
                if (!char.IsNumber(expression[index]))
                {
                    throw new ArgumentException($"Unexpected character in {expression} at {startIndex}");
                }
            }

            return new TokenProviderResult(startIndex, index - 1, new NumberToken(expression.Substring(startIndex, index - startIndex)));
        }
    }
}
