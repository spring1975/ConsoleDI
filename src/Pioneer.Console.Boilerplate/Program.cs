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

            //Start watching file system
            serviceProvider.GetService<FileWatcher>().StartWatching();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add logging
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            serviceCollection.AddLogging();
            serviceCollection = serviceCollection.AddMyServiceDependencies();
            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("Configuration"));
            ConfigureConsole(configuration);

            // add FileWatcher and FileProcessor
            serviceCollection.AddTransient<FileWatcher>();
            serviceCollection.AddTransient<FileProcessor>();
        }

        private static void ConfigureConsole(IConfigurationRoot configuration)
        {
            System.Console.Title = configuration.GetSection("Configuration:ConsoleTitle").Value;
        }
    }
}
