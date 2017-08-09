namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class FieldToken : IToken
    {
        public string Value { get; }
        public FieldToken(string value)
        {
            this.Value = value;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
