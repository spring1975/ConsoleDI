using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using LogicService.Interfaces;

namespace ConsoleApp
{
    public class FileWatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private FileProcessor _fileProcessor;

        public FileWatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            
            //Don't create service here
            _fileProcessor = _serviceProvider.GetService<FileProcessor>();
        }

        public void StartWatching()
        {
            var prompt = "Press (Y) to call service, (A) to add new City, or (N) to exit.";
            System.Console.WriteLine(prompt);

            while (true)
            {
                var result = System.Console.ReadKey();
                if (result.KeyChar == 'Y' || result.KeyChar == 'y')
                {
                    //_fileProcessor.ProcessFile();
                    _serviceProvider.GetService<FileProcessor>().ProcessFile();
                }
                else if (result.KeyChar == 'A' || result.KeyChar == 'a')
                {
                    System.Console.Clear();
                    System.Console.WriteLine("Please enter new City name: ");
                    var name = System.Console.ReadLine();
                    var service = _serviceProvider.GetService<ICityService>();
                    service.AddCity(name);
                    System.Console.WriteLine($"City {name} Added");

                    //TODO: there's a better way to do this instead of locking up the main thread.
                    Thread.Sleep(500);
                }
                else if (result.KeyChar == 'X' || result.KeyChar == 'x')
                {
                    //exit
                    break;
                }

                System.Console.Clear();
                System.Console.WriteLine(prompt);
            }
        }
    }
}
