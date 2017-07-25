using System;

namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class LiteralTokenProvider : ITokenProvider
    {
        public TokenProviderResult GetToken(int startIndex, string expression)
        {
            if (expression[startIndex] == ' ' || expression[startIndex] == '\'')
                throw new ArgumentException($"Invalid beginning in {expression} at {startIndex}");

            var index = startIndex + 1;
            while (expression.Length > index)
            {
                if (expression[index] == ' ')
                    break;

                index += 1;
            }

            return new TokenProviderResult(startIndex, index - 1, new LiteralToken(expression.Substring(startIndex, index - startIndex)));
        }
    }
}
