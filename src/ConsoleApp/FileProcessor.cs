using LogicService.Interfaces;

namespace ConsoleApp
{
    public class FileProcessor
    {
        private readonly ITestService _testService;

        public FileProcessor(ITestService testService)
        {
            _testService = testService;
        }

        public void ProcessFile()
        {
            _testService.PrintLines();
        }
    }
}
