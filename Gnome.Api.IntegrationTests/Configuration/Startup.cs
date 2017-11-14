using Gnome.Api.AuthenticationMiddleware;
using Gnome.Api.Filters;
using Gnome.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Gnome.Api.IntegrationTests.Configuration
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new UserFilter());
            });

            var signKey = TokenProviderOptionFactory.GetKey();

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
            return container.GetInstance<IServiceProvider>();
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

            var signKey = TokenProviderOptionFactory.GetKey();
            var options = GetTokenProviderOptions(signKey);

            app.UseMiddleware<TestIdentityMiddleware>(Options.Create(options));
            app.UseAuthentication();
            app.UseMvc();
        }

        private TokenValidationParameters GetTokenValidationParameters(SymmetricSecurityKey signingKey)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false, //TODO should be true
                IssuerSigningKey = signingKey,
                ValidateIssuer = false,
                ValidIssuer = TokenProviderOptionFactory.ISSUER,
                ValidateAudience = false,
                ValidAudience = TokenProviderOptionFactory.AUDIENCE,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };
            return tokenValidationParameters;
        }

        private static TokenProviderOptions GetTokenProviderOptions(SymmetricSecurityKey signingKey)
        {
            return TokenProviderOptionFactory.Create();
        }
    }
}