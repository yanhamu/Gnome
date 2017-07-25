namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class StringToken : IToken
    {
        public StringToken(string value)
        {
            this.Value = value;
        }

        public string Value { get; }
    }
}