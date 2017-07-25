namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class Tokenizer
    {
        private readonly string expression;

        public Tokenizer(string expression)
        {
            this.expression = expression.Trim();
        }
    }
}