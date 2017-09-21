using Autofac;
using Gnome.Api.AuthenticationMiddleware;
using Gnome.Api.Filters;
using Gnome.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Gnome.Api.IntegrationTests.Configuration
{
    public class Startup
    {
        public const string SECRET_KEY = "this is my secret";

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new UserFilter());
            });

            var signKey = GetKey(SECRET_KEY);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = GetTokenValidationParameters(signKey);
                });

            services.AddCors();
            var container = DiConfiguration.CreateContainer(services);
            return container.Resolve<IServiceProvider>();
        }


        public void Configure(IApplicationBuilder app, Initializer initializer)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            if (initializer.HasAllTables() == false)
                initializer.DropAndCreate();
            var options = GetTokenProviderOptions(GetKey(SECRET_KEY));
            app.UseMiddleware<TestIdentityMiddleware>(Options.Create(options));
            app.UseAuthentication();
            app.UseMvc();
        }
        private SymmetricSecurityKey GetKey(string v) => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(v));

        private TokenValidationParameters GetTokenValidationParameters(SymmetricSecurityKey signingKey)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = "ExampleIssuer",

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = "ExampleAudience",

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };
            return tokenValidationParameters;
        }

        private static TokenProviderOptions GetTokenProviderOptions(SymmetricSecurityKey signingKey)
        {
            return new TokenProviderOptions()
            {
                Audience = "ExampleAudience",
                Issuer = "ExampleIssuer",
                Expiration = TimeSpan.FromMinutes(30),
                Path = "/api/gettoken",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            };
        }
    }
}