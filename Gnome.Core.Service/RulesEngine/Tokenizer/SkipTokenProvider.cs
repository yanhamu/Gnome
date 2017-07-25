using System;

namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class SkipTokenProvider : ITokenProvider
    {
        public TokenProviderResult GetToken(int startIndex, string expression)
        {
            if (expression[startIndex] != ' ')
                throw new ArgumentException($"Invalid start character. Expected \" \" in {expression} at {startIndex}");
            var index = startIndex + 1;

            while (expression.Length > index)
            {
                if (expression[index] == ' ')
                    index += 1;
                else
                    break;
            }
            return new TokenProviderResult(startIndex, index - 1, new SkipToken(expression.Substring(startIndex, index - startIndex)));
        }
    }
}
