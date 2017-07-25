namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class LiteralToken : IToken
    {
        public LiteralToken(string value)
        {
            this.Value = value;
        }

        public string Value { get; }
    }
}