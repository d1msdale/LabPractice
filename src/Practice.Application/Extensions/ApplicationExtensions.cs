using Microsoft.Extensions.DependencyInjection;
using Practice.Application.Implementations;
using Practice.Application.Interfaces;

namespace Practice.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddScoped<ITestService, TestService>();
        return services;
    }
}