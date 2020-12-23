using Autofac;
using Library.WebAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.IO;

namespace Library.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Extensions/ServiceExtensions.cs
            services.ConfigureCors();
            services.ConfigureControllers();
            services.ConfigureSqlServer(Configuration);
            services.ConfigureIdentity();
            services.ConfigureAutoMapper();
            services.ConfigureSwagger();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Extensions/ServiceExtensions.cs
            builder.ConfigureAutoFac();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.ConfigureExceptionMiddleware();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}