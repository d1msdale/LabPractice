using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practice.Infrastructure.Configuration;

namespace Practice.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<PracticeDbContext>(options => { options.UseNpgsql(connectionString); });
        return services;
    }
}