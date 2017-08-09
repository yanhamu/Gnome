namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class StringToken : IOperand
    {
        public StringToken(string value)
        {
            this.Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return "'" + Value + "'";
        }
    }
}