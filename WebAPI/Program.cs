using WebAPI.config;

var builder = WebApplication.CreateBuilder(args);
var applicationCorsOrigins = "applicationCorsOrigins";

ConfigurationManager configurationManager = builder.Configuration;
var appRegistrations = new RegisterServices();
appRegistrations.Onload(builder.Services, configurationManager);

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseUrls("http://*:5000");
        webBuilder.UseStartup<WebApplication>();
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseForwardedHeaders();
app.UseRouting();
app.UseCors(applicationCorsOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


