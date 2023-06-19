using BusinessClockApi.Models;



namespace BusinessClockApi.Services;



public class BusinessClockService
{
    private readonly ISystemTime _systemTime;



    public BusinessClockService(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }



    public GetStatusResponse GetCurrentStatus()
    {
        DateTime now = _systemTime.GetCurrent();
        bool isOpen = now.DayOfWeek != DayOfWeek.Sunday && now.DayOfWeek != DayOfWeek.Saturday;
        return new GetStatusResponse { Open = isOpen };
    }
}



public interface ISystemTime
{
    DateTime GetCurrent();
}



public class SystemTime : ISystemTime
{
    public DateTime GetCurrent()
    {
        return DateTime.Now;
    }
}