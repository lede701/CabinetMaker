using CabinetMaker.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CabinetMaker.DAL.Extensions;

public static class DatabaseProviderExtensions
{
    public static IServiceCollection AddCabinetMakerDatabase(this IServiceCollection services, DalServiceConfiguration config)
    {
        if (string.IsNullOrEmpty(config.DatabaseConnectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
        }

        services.AddDbContext<CmContext>(options =>
        {
            if (config.DatabaseProvider.Equals("MySql", StringComparison.OrdinalIgnoreCase))
                options.UseMySQL(config.DatabaseConnectionString);
            else if (config.DatabaseProvider.Equals("SqlServer", StringComparison.OrdinalIgnoreCase))
                options.UseSqlServer(config.DatabaseConnectionString);
            else
                throw new InvalidOperationException(
                    $"Unsupported database provider: '{config.DatabaseProvider}'. Valid values are 'MySql' or 'SqlServer'.");
        });

        return services;
    }
}
