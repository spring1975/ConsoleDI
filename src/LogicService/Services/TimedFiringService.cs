using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LogicService.Models;
using LogicService.Interfaces;

namespace LogicService.Services
{
    public class TimedFiringService: ITimedFiringService
    {
        private readonly ILogger<TimedFiringService> _logger;
        private readonly AppSettings _config;
        //private int eventId = 1;
        private int _myCount;

        public TimedFiringService(ILogger<TimedFiringService> logger,
            IOptions<AppSettings> config)
        {
            _logger = logger;
            _config = config.Value;
        }

        public void StartTimer()
        {
            // Set up a timer to trigger every minute.  
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 600; // 60 seconds  
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            _logger.LogWarning($"If this is injected as transient, count should always been 1.  Otherwise, it should increment whether it's Singleton or Scoped.");
            _logger.LogInformation($"My count is now: {++_myCount}");
        }
    }
}
