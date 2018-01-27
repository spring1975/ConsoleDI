using Microsoft.Extensions.DependencyInjection;
using StandardService.Services;
using DataStandard;

namespace StandardService
{
    public static class StandardServiceComposition
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
