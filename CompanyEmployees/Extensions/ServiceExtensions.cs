﻿using Contracts;
using LoggerServices;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.Contracts;

namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin() //WithOrigin("http://frontend-app.com")
                .AllowAnyMethod() //WithMethods ("POST","GET") only this type of methods for example
                .AllowAnyHeader()); //WithHeaders("content-type") etc.
            });

        public static void ConfigureIisIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
                // We do not initialize any of the properties inside the options because we are fine with the default values for now.
            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }
}
