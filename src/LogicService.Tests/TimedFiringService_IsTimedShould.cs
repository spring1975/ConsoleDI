using NUnit.Framework;
using LogicService.Services;
using LogicService.Interfaces;
using LogicService.Models;
using Microsoft.Extensions.Options;
using System.Threading;

namespace LogicService.Tests
{
    [TestFixture]
    public class TimedFiringService_IsTimedShould
    {
        private readonly ITimedFiringService _timedFiringService;
        public TimedFiringService_IsTimedShould()
        {
            var logger = NSubstitute.Substitute.For<Microsoft.Extensions.Logging.ILogger<TimedFiringService>>();
            var config = NSubstitute.Substitute.For<IOptions<AppSettings>>();

            _timedFiringService = new TimedFiringService(logger, config);

        }
        [Test]
        public void TestMethod1()
        {
            _timedFiringService.StartTimer();
            Thread.Sleep(1000);
        }
    }
}
