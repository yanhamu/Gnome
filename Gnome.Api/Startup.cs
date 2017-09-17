using Autofac;
using Gnome.Api.AuthenticationMiddleware;
using Gnome.Api.Configuration;
using Gnome.Api.Filters;
using Gnome.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Text;

namespace Gnome.Api
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            var signingKey = GetKey(configuration);

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
                    o.TokenValidationParameters = GetTokenValidationParameters(signingKey);
                });

            services.AddCors();
            var container = DiConfiguration.CreateContainer(services);
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, Initializer initializer)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            loggerFactory.AddConsole();


            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var signingKey = GetKey(configuration);
            var options = GetTokenProviderOptions(signingKey);

            if (initializer.HasAllTables() == false)
                initializer.DropAndCreate();

            app.UseStaticFiles();

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
            app.UseAuthentication();

            app.UseMvc();
        }

        private static SymmetricSecurityKey GetKey(IConfigurationRoot configuration)
        {
            var secretKey = configuration["key"];
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            return signingKey;
        }
        private static TokenValidationParameters GetTokenValidationParameters(SymmetricSecurityKey signingKey)
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
