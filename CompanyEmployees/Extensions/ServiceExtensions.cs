namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions //is this in use now? Shouldn't it be called in Program.cs
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

    }
}
