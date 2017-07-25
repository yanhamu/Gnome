using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class Tokenizer
    {
        private readonly string expression;

        public IEnumerable<IToken> GetTokens(string expression)
        {
            var index = 0;

            while (expression.Length > index)
            {
                var provider = GetTokenProvider(expression, index);
                var result = provider.GetToken(index, expression);
                index = result.EndIndex;
                index += 1;
                yield return result.Token;
            }
        }

        private static ITokenProvider GetTokenProvider(string expression, int index)
        {
            var provider = default(ITokenProvider);
            switch (expression[index])
            {
                case '\'':
                    provider = new StringTokenProvider();
                    break;
                case ' ':
                    provider = new SkipTokenProvider();
                    break;
                default:
                    provider = new LiteralTokenProvider();
                    break;
            }

            return provider;
        }
    }
}