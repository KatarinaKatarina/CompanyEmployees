namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions //is this in use now? Shouldn't it be called in Program.cs
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin() //WithOrigin("http://frontend-app.com")
                .AllowAnyMethod() //WithMethods ("POST","GET") only this tpe of methods for example
                .AllowAnyHeader()); //WithHeaders("content-type") etc.
            });
    }
}
