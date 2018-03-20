using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LogicService;
using LogicService.Models;

namespace ConsoleApp
{
    public class Program
    {
        private static IConfiguration Configuration { get; set; }

        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, Configuration);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //Start watching file system
            serviceProvider.GetService<FileWatcher>().StartWatching();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // add logging
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            serviceCollection.AddLogging();
            serviceCollection = serviceCollection.AddMyServiceDependencies(configuration);
            // build configuration
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configurationBuilder.GetSection("Configuration"));
            ConfigureConsole(configurationBuilder);

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
