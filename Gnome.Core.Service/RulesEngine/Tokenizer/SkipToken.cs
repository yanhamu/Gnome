namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class SkipToken : IToken
    {
        public SkipToken(string value)
        {
            this.Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return this.Value;
        }
    }
}