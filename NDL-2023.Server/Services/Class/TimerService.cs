using NDL_2023.Server.Data;
using NDL_2023.Server.Services.Interfaces;

namespace NDL_2023.Server.Services.Class;

public class TimerService: ITimerService
{
    private readonly EntityContext _context;

    public TimerService(EntityContext context)
    {
        _context = context;
    }

    private long GetSecondsFromJanuary1970()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    public long GetStartTime()
    {
        return GetSecondsFromJanuary1970();
    }

    public long GetStopTime()
    {
        return GetSecondsFromJanuary1970();
    }
}