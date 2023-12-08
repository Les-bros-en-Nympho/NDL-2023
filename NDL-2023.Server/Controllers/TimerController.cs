using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NDL_2023.Server.Services.Interfaces;

namespace NDL_2023.Server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TimerController : ControllerBase
{
    private readonly ITimerService _timerService;
    private const string KeyTimer = "__TIMER_KEY__";

    public TimerController(ITimerService timerService)
    {
        _timerService = timerService;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("set_start_time_to_session")]
    public void SetStartTimeToSession()
    {
        long startTime = _timerService.GetStartTime();
        HttpContext.Session.SetString(KeyTimer, startTime.ToString());
    }
}