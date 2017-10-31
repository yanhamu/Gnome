using Gnome.Core.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gnome.Api.AuthenticationMiddleware
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;

        public TokenProviderMiddleware(
            RequestDelegate next,
            IOptions<TokenProviderOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public Task Invoke(HttpContext context, IUserService userService)
        {
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
                return _next(context);

            if (!context.Request.Method.Equals("POST")
               || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return Task.FromResult(0);
            }

            if (!context.Request.Form.ContainsKey("username") || !context.Request.Form.ContainsKey("password"))
            {
                context.Response.StatusCode = 400;
                return Task.FromResult(0);
            }

            return GenerateToken(context, userService);
        }

        private async Task GenerateToken(HttpContext context, IUserService userService)
        {
            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];

            var identity = GetIdentity(username, password, userService);

            if (identity == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;
            var nowDateTimeOffset = new DateTimeOffset(now);

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, nowDateTimeOffset.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            };
            claims.AddRange(identity.Claims);

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds
            };

            context.Response.ContentType = "application/json";
            var stringResponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented });
            await context.Response.WriteAsync(stringResponse);
        }

        private ClaimsIdentity GetIdentity(string username, string password, IUserService userService)
        {
            var user = userService.Verify(username, password);
            if (user == null)
                return null;

            return new ClaimsIdentity(new System.Security.Principal.GenericIdentity(username, "Token"), new Claim[] { new Claim("user_id", user.Id.ToString()) });

        }
    }
}
