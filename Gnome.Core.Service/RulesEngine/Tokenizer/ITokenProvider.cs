namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public interface ITokenProvider
    {
        TokenProviderResult GetToken(int startIndex, string expression);
    }
}
