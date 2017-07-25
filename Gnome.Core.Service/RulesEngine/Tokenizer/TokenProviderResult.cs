namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class TokenProviderResult
    {
        public IToken Token { get; private set; }
        public int StartIndex { get; private set; }
        public int EndIndex { get; private set; }

        public TokenProviderResult(int start, int end, IToken token)
        {
            this.Token = token;
            this.StartIndex = start;
            this.EndIndex = end;
        }
    }
}