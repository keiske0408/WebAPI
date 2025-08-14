using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Commands.Handler;
using WebAPI.db;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.TestRepository;
using WebAPI.Services;

namespace WebAPI.config;

public class RegisterServices
{
    public void Onload(IServiceCollection services, IConfiguration configuration)
    {
        
        RegisterLocalDb(services,configuration);
        AllServices(services);
        ServiceOnLoad(services);
        RegisterSwagger(services);
    }

    public static void RegisterLocalDb(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["connectionStrings:localDb"];
        services.AddDbContext<ApplicationDatabase>(options =>
            options.UseSqlServer(connectionString, provider => provider.EnableRetryOnFailure()));
    }

    public static void AllServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddAuthorization();
        services.AddControllers();
    }

    public static void RegisterSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "The API Key is needed",
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "ApiKeyScheme"
                });
            var scheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            };
            var requirement = new OpenApiSecurityRequirement
            {
                { scheme, new List<string>() }
            };
            c.AddSecurityRequirement(requirement);
        });
    }

    private void ServiceOnLoad(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddScoped(typeof(IRepository<TestModel>), typeof(TestRepositoryData));
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<TestDataCommandHandler>();
        services.AddMediatR(typeof(Program).Assembly);
    }
}


