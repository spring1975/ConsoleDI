using DataFramework;
using DataStandard;
using LogicService.Services;
using LogicService.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace LogicService
{
    public static class LogicServiceComposition
    {
        public static IServiceCollection AddMyServiceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<LocationsContext>();
            services.AddTransient<EF6DBContext>();

            services.AddDbContext<LocationsContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("AppConnection")),
                ServiceLifetime.Transient,
                ServiceLifetime.Transient);
            
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IStatesService, StatesService>();
            return services;
        }
    }
}
