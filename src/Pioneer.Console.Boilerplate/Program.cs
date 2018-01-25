using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StandardService;
using StandardService.Models;
using StandardService.Services;

namespace Pioneer.Console.Boilerplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            while (true)
            {
                ConsoleKeyInfo result = System.Console.ReadKey();
                if ((result.KeyChar == 'Y') || (result.KeyChar == 'y'))
                {
                    serviceProvider.GetService<App>().Run();
                }
                else if ((result.KeyChar == 'N') || (result.KeyChar == 'n'))
                {
                    System.Console.WriteLine("I wont do anything");
                    break;
                }
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add logging
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            serviceCollection.AddLogging();
            serviceCollection.AddMyServiceDependencies();
            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("Configuration"));
            ConfigureConsole(configuration);
      
            // add app
            serviceCollection.AddTransient<App>();
        }

        private static void ConfigureConsole(IConfigurationRoot configuration)
        {
            System.Console.Title = configuration.GetSection("Configuration:ConsoleTitle").Value;
        }
    }
}
