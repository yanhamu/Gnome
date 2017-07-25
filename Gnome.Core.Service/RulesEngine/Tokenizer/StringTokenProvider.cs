using System;

namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class StringTokenProvider : ITokenProvider
    {
        public TokenProviderResult GetToken(int startIndex, string expression)
        {
            if (expression[startIndex] != '\'')
                throw new ArgumentException($"Invalid start character. Expected \"'\" in {expression} at {startIndex}");

            var index = startIndex + 1;
            while (expression.Length > index)
            {
                if (IsDoubledApostrophe(expression, index))
                {

                    index += 2;
                    continue;
                }
                if (expression[index] == '\'')
                {
                    break;
                }
                index += 1;
            }

            return new TokenProviderResult(startIndex, index, new StringToken(expression.Substring(startIndex, index - startIndex + 1)));
        }

        private bool IsDoubledApostrophe(string expression, int index)
        {
            if (expression.Length <= index + 1)
                return false;
            return expression[index] == '\'' && expression[index + 1] == '\'';
        }
    }
}
