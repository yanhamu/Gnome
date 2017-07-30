using System;
using System.Text;

namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class StringTokenProvider : ITokenProvider
    {
        public TokenProviderResult GetToken(int startIndex, string expression)
        {
            if (expression[startIndex] != '\'')
                throw new ArgumentException($"Invalid start character. Expected \"'\" in {expression} at {startIndex}");

            var index = startIndex + 1;
            var sb = new StringBuilder();
            while (expression.Length > index)
            {
                if (IsDoubledApostrophe(expression, index))
                {
                    sb.Append(expression[index]);
                    index += 2;
                    continue;
                }
                if (expression[index] == '\'')
                {
                    break;
                }
                sb.Append(expression[index]);
                index += 1;
            }

            // TODO String token should not contain ' anymore... we know that it is string now
            return new TokenProviderResult(startIndex, index, new StringToken(sb.ToString()));
        }

        private bool IsDoubledApostrophe(string expression, int index)
        {
            if (expression.Length <= index + 1)
                return false;
            return expression[index] == '\'' && expression[index + 1] == '\'';
        }
    }
}
