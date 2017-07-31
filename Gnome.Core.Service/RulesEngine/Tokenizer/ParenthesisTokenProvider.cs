using System;

namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class ParenthesisTokenProvider : ITokenProvider
    {
        public TokenProviderResult GetToken(int startIndex, string expression)
        {
            var token = GetToken(expression, startIndex);
            return new TokenProviderResult(startIndex, startIndex, token);
        }

        private IToken GetToken(string expression, int index)
        {
            switch (expression[index])
            {
                case '(':
                    return new OpenParenthesisToken();
                case ')':
                    return new ClosingParenthesisToken();
                default:
                    throw new ArgumentException($"Expected open/close parenthesis in {expression} at {index}");
            }
        }
    }
}