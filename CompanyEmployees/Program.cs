using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Routing;
using NLog;


/* 
 The WebApplicationBuilder class is responsible for:
        Adding Configuration to the project by using the builder.Configuration property
        Registering services in our app with the builder.Services property
        Logging configuration with the builder.Logging property
        Other IHostBuilder and IWebHostBuilder configuration
*/

/*
 There is no the Startup class with two familiar methods: ConfigureServices and Configure,
 so we can do that right below the builder variable declaration (in Program.cs)
*/





var builder = WebApplication.CreateBuilder(args);

//add logger
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.    = ConfigureServices method in .Net 5 (add services)
builder.Services.ConfigureCors();
builder.Services.ConfigureIisIntegration();
builder.Services.ConfigureLoggerService();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly); //for api to know where to route incoming requests
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.     = Configure method in .Net 5 (add middlewares)
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();// adds the Strict-Transport-Security header
app.UseHttpsRedirection();//adding middleware for http -->https redirection
app.UseStaticFiles(); //enables using static files for the request. If we don�t set a path to the static files directory, it will use a wwwroot folder in our project by defaul
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All // will forward proxy headers to the current request :/ ?
});
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers(); //or app.UseRouting() for default routing

app.Run();


/*Compared to the Program.cs class from .NET 5, there are some major changes.Some of the most obvious are:
    Top - level statements (no class blocks in the code nor the Main method - will be created by compiler)
    Implicit using directives (for Microsoft packages, System packages etc. Can be disabled in .csproj)
    No Startup class (on the project level)
*/