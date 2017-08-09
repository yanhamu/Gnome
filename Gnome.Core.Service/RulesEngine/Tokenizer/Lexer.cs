using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class Lexer
    {
        private readonly Dictionary<Type, ITokenProvider> providerCache;
        private readonly Dictionary<string, int> operatorKeywords;
        private readonly HashSet<char> stopCharacters;

        public Lexer()
        {
            this.operatorKeywords = new Dictionary<string, int>() {
                { "=", 10 },
                { "!=", 10 },
                { "<", 10 },
                { ">", 10 },
                { "<=", 10 },
                { ">=", 10 },
                { "contains", 10 },
                { "and", 2 },
                { "or", 2 },
                { "not", 2 }
            };
            this.stopCharacters = new HashSet<char>() { ' ', '(', ')' };
            this.providerCache = InitializeProviderCache();
        }

        private Dictionary<Type, ITokenProvider> InitializeProviderCache()
        {
            var dict = new Dictionary<Type, ITokenProvider>();
            dict.Add(typeof(StringTokenProvider), new StringTokenProvider());
            dict.Add(typeof(SkipTokenProvider), new SkipTokenProvider());
            dict.Add(typeof(NumberTokenProvider), new NumberTokenProvider(this.stopCharacters));
            dict.Add(typeof(ParenthesisTokenProvider), new ParenthesisTokenProvider());
            dict.Add(typeof(LiteralTokenProvider), new LiteralTokenProvider(this.operatorKeywords, this.stopCharacters));
            return dict;
        }

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

        private ITokenProvider GetTokenProvider(string expression, int index)
        {
            var provider = default(ITokenProvider);
            switch (expression[index])
            {
                case '\'':
                    provider = GetProvider<StringTokenProvider>();
                    break;
                case ' ':
                    provider = GetProvider<SkipTokenProvider>();
                    break;
                case char number when char.IsNumber(number):
                    provider = GetProvider<NumberTokenProvider>();
                    break;
                case '(':
                    provider = GetProvider<ParenthesisTokenProvider>();
                    break;
                case ')':
                    provider = GetProvider<ParenthesisTokenProvider>();
                    break;
                default:
                    provider = GetProvider<LiteralTokenProvider>();
                    break;
            }

            return provider;
        }

        private ITokenProvider GetProvider<T>()
        {
            return providerCache[typeof(T)];
        }
    }
}