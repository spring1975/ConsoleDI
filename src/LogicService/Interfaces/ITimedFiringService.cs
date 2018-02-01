namespace LogicService.Interfaces
{
    public interface ITimedFiringService
    {
        void StartTimer();
        void OnTimer(object sender, System.Timers.ElapsedEventArgs args);
    }
}