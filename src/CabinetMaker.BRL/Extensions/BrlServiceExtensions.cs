using CabinetMaker.BRL.Services;
using CabinetMaker.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CabinetMaker.BRL.Extensions;

public static class BrlServiceExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        => AddBusinessLayer(services, new BrlServiceConfiguration());

    public static IServiceCollection AddBusinessLayer(this IServiceCollection services, Action<BrlServiceConfiguration> configure)
    {
        var config = new BrlServiceConfiguration();
        configure(config);
        return AddBusinessLayer(services, config);
    }

    public static IServiceCollection AddBusinessLayer(this IServiceCollection services, BrlServiceConfiguration config)
    {
        services.AddSingleton(config);
        services.AddScoped<DbSeeder>();
        services.AddScoped<IMeasurementService, MeasurementService>();
        services.AddScoped<IRecordSuccessionService, RecordSuccessionService>();
        services.AddScoped<IMaterialResolutionService, MaterialResolutionService>();
        services.AddScoped<IMaterialService, MaterialService>();
        return services;
    }
}
