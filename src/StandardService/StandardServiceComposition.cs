using Microsoft.Extensions.DependencyInjection;
using StandardService.Services;

namespace StandardService
{
    public static class StandardServiceComposition
    {
      public static IServiceCollection AddMyServiceDependencies(this IServiceCollection services)
      {
        services.AddTransient<ITestService, TestService>();
        return services;
    }
  }
}
