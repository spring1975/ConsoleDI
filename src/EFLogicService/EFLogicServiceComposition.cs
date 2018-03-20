using DataFramework;
using EFLogicService.Interfaces;
using EFLogicService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EFLogicService
{
    public static class EFLogicServiceComposition
    {
        public static IServiceCollection AddMyServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<EF6DBContext>();
            
            services.AddTransient<IWidgetService, WidgetService>();
            return services;
        }
    }
}
