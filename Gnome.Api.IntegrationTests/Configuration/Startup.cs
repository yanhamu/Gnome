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

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = GetTokenValidationParameters();
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

            var options = TokenProviderOptionFactory.Create();

            app.UseMiddleware<TestIdentityMiddleware>(Options.Create(options));
            app.UseAuthentication();
            app.UseMvc();
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = TokenProviderOptionFactory.GetKey(),
                ValidateIssuer = true,
                ValidIssuer = TokenProviderOptionFactory.ISSUER,
                ValidateAudience = true,
                ValidAudience = TokenProviderOptionFactory.AUDIENCE,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            return tokenValidationParameters;
        }
    }
}