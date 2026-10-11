using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CabinetMaker.Web.Views.Extensions;

public static class ViewServiceExtension
{
    public static IServiceCollection AddViewLayer(this IServiceCollection services)
    {
        var assembly = typeof(ViewServiceExtension).Assembly;

        var viewModelTypes = assembly.GetTypes()
            .Where(t => t is { IsAbstract: false, IsClass: true }
                     && t.IsAssignableTo(typeof(ObservableObject)));

        foreach (var type in viewModelTypes)
            services.AddScoped(type);

        return services;
    }
}
