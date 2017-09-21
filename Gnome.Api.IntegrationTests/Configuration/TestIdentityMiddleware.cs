using Gnome.Api.AuthenticationMiddleware;
using Gnome.Api.IntegrationTests.Fixtures;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gnome.Api.IntegrationTests.Configuration
{
    public class TestIdentityMiddleware
    {
        private RequestDelegate next;
        private readonly TokenProviderOptions options;
        public const string AUTH_HEADER_FLAG = "test_auth";

        public TestIdentityMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options)
        {
            this.next = next;
            this.options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey(AUTH_HEADER_FLAG))
            {
                var now = DateTime.UtcNow;
                var claims = GetClaims(now);

                var jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(options.Expiration),
                signingCredentials: options.SigningCredentials);
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                context.Request.Headers.Add("Authorization", new Microsoft.Extensions.Primitives.StringValues("bearer " + encodedJwt));
            }

            await next.Invoke(context);
        }

        public List<Claim> GetClaims(DateTime now)
        {
            var nowDateTimeOffset = new DateTimeOffset(now);
            return new List<Claim>() {
            new Claim(JwtRegisteredClaimNames.Sub, "test_user"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, nowDateTimeOffset.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim("user_id", UserFixture.User.Id.ToString())
            };
        }
    }
}