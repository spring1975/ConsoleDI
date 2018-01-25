using System;
using Microsoft.Extensions.DependencyInjection;

namespace Pioneer.Console.Boilerplate
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
            System.Console.WriteLine("Press (Y) to call service, (N) to exit.");
            while (true)
            {
                var result = System.Console.ReadKey();
                if (result.KeyChar == 'Y' || result.KeyChar == 'y')
                {
                    //_fileProcessor.ProcessFile();
                    _serviceProvider.GetService<FileProcessor>().ProcessFile();
                }
                else if (result.KeyChar == 'N' || result.KeyChar == 'n')
                {
                    //exit
                    break;
                }
            }
        }
    }
}
