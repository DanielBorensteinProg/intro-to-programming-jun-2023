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
        var dayofTheWeek = now.DayOfWeek;
        var hour = now.Hour;

        var openingTime = new TimeSpan(9, 0, 0);
        var closingTime = new TimeSpan(17,0,0);

        var isOpen = dayofTheWeek switch
        {
            DayOfWeek.Saturday => false,
            DayOfWeek.Sunday => false,
            _ => hour >= openingTime.Hours && hour < closingTime.Hours,
        };

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