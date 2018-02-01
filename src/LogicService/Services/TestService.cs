using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LogicService.Models;
using LogicService.Interfaces;

//https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit

namespace LogicService.Services
{
    public class TestService : ITestService
    {
        private int _myCount;
        private readonly ILogger<TestService> _logger;
        private readonly AppSettings _config;

        public TestService(ILogger<TestService> logger,
            IOptions<AppSettings> config)
        {
            _logger = logger;
            _config = config.Value;
            _myCount = 0;
        }

        public void PrintLines()
        {
            _logger.LogWarning($"If this is injected as transient, count should always been 1.  Otherwise, it should increment whether it's Singleton or Scoped.");
            _logger.LogInformation($"My count is now: {++_myCount}");
        }
    }
}
