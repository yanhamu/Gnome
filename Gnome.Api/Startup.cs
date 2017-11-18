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

            var signingKey = GetKey(configuration["key"]);

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
            return container.GetInstance<IServiceProvider>();
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
                app.UseDeveloperExceptionPage();

            if (initializer.HasAllTables() == false)
                initializer.DropAndCreate();

            app.UseStaticFiles();

            var signingKey = GetKey(configuration["key"]);
            var options = GetTokenProviderOptions(signingKey);
            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
            app.UseAuthentication();

            app.UseMvc();
        }

        private static SymmetricSecurityKey GetKey(string secretKey) => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

        private static TokenValidationParameters GetTokenValidationParameters(SymmetricSecurityKey signingKey)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                ValidateIssuer = true,
                ValidIssuer = issuer,

                ValidateAudience = true,
                ValidAudience = audience,

                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };
            return tokenValidationParameters;
        }

        private const string issuer = "gnome-default";
        private const string audience = "gnome-default";

        private static TokenProviderOptions GetTokenProviderOptions(SymmetricSecurityKey signingKey)
        {
            return new TokenProviderOptions(
                "/api/gettoken",
                issuer,
                audience,
                TimeSpan.FromHours(2),
                new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
        }
    }
}
