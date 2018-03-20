using System.Configuration;
using System.ServiceProcess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using LogicService;
using System.IO;
using LogicService.Models;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

//https://docs.microsoft.com/en-us/dotnet/framework/windows-services/walkthrough-creating-a-windows-service-application-in-the-component-designer

namespace WindowsService
{
    public class Program
    {
        private static IConfiguration Configuration { get; set; }

        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                serviceProvider.GetService<MyWindowsService>()
                //new MyWindowsService()
            };
            ServiceBase.Run(ServicesToRun);
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add logging
            serviceCollection.AddSingleton(new LoggerFactory()
                //.AddDebug()
                );
            serviceCollection.AddLogging();
            serviceCollection = serviceCollection.AddMyServiceDependencies(Configuration);
            // build configuration

            //The following needed Microsoft.Extensions.Options.ConfigurationExtensions to work
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("Configuration"));
            ConfigureWindowsService(configuration);

            // add FileWatcher and FileProcessor
            //serviceCollection.AddTransient<FileWatcher>();
            //serviceCollection.AddTransient<FileProcessor>();
        }
        private static void ConfigureWindowsService(IConfigurationRoot configuration)
        {
            System.Console.Title = configuration.GetSection("Configuration:ConsoleTitle").Value;
        }

    }
}
