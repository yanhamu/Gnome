using Microsoft.IdentityModel.Tokens;
using System;

namespace Gnome.Api.AuthenticationMiddleware
{
    public class TokenProviderOptions
    {
        public string Path { get; }

        public string Issuer { get; }

        public string Audience { get; }

        public TimeSpan Expiration { get; }

        public SigningCredentials SigningCredentials { get; }

        public TokenProviderOptions(string path, string issuer, string audience, TimeSpan expiration, SigningCredentials credentials)
        {
            this.Path = path;
            this.Issuer = issuer;
            this.Audience = audience;
            this.Expiration = expiration;
            this.SigningCredentials = credentials;
        }

        public TokenProviderOptions()
        {

        }
    }
}