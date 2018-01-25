using StandardService.Services;

namespace Pioneer.Console.Boilerplate
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
