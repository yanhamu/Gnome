using Gnome.Api.AuthenticationMiddleware;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Gnome.Api.IntegrationTests
{
    public class TokenProviderOptionFactory
    {
        public const string PATH = "/gettoken";
        public const string ISSUER = "ExampleIssuer";
        public const string AUDIENCE = "ExampleAudience";
        public static TimeSpan expiration = TimeSpan.FromHours(2);
        public const string SECRET = "dirty little secret";

        public static TokenProviderOptions Create()
        {
            var credentials = new SigningCredentials(GetKey(), SecurityAlgorithms.HmacSha256);
            return new TokenProviderOptions(PATH, ISSUER, AUDIENCE, expiration, credentials);
        }

        public static SymmetricSecurityKey GetKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET));

    }
}
