using Autofac;
using Gnome.Api.IntegrationTests;
using Gnome.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gnome.Api
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            var container = DiConfiguration.CreateContainer(services);
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Initializer initializer)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            if (initializer.HasAllTables() == false)
                initializer.Initialize(true);

            app.UseMvc();
        }
    }
}