using Microsoft.Extensions.DependencyInjection;
using LogicService.Services;
using LogicService.Interfaces;
using DataStandard;

namespace LogicService
{
    public static class LogicServiceComposition
    {
          public static IServiceCollection AddMyServiceDependencies(this IServiceCollection services)
          {
                services.AddTransient<ITestService, TestService>();
                services.AddTransient<LocationsContext>();
                services.AddTransient<ICityService, CityService>();
                services.AddTransient<IStatesService, StatesService>();
                return services;
          }
    }
}
