using Library.DAL;
using Library.Repository;
using Library.Repository.Common;
using Library.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                    );
            });
        }

        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConnections = new ConnectionStrings();
            configuration.Bind("ConnectionStrings", databaseConnections);

            services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(databaseConnections.LibraryDbConnectionString, x =>
                    x.MigrationsAssembly("WebAPI")));
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}