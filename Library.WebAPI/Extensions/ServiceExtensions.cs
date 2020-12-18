using AutoMapper;
using Library.Common.Mapping;
using Library.DAL;
using Library.DAL.Entities;
using Library.Repository;
using Library.Repository.Common;
using Library.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

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
                    x.MigrationsAssembly("Library.WebAPI")));
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<UserEntity, RoleEntity>()
                .AddEntityFrameworkStores<LibraryDbContext>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new Action<IMapperConfigurationExpression>(options =>
            {
                options.AddProfile<UserProfile>();
                options.AddProfile<RoleProfile>();
                options.AddProfile<AuthorProfile>();
                options.AddProfile<BookProfile>();
            });

            services.AddAutoMapper(mapperConfig);
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library.WebAPI", Version = "v1" });
            });
        }
    }
}