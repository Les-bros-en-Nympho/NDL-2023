using backend.Adapters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NDL_2023.Server.Data.Tables;
using NDL_2023.Server.Services.Interfaces;

namespace NDL_2023.Server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TrueOrFalseController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITimerService _timerService;
    private readonly ITrueOrFalseService _trueOrFalseService;
    private const string KeyTimer = "__TIMER_KEY__";
    private const string KeyID = "__ID_KEY__";

    public TrueOrFalseController(ITimerService timerService, IUserService userService, ITrueOrFalseService trueOrFalseService)
    {
        _timerService = timerService;
        _userService = userService;
        _trueOrFalseService = trueOrFalseService;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("random")]
    public string GetRandomTrueOrFalse()
    {
        var last_id = HttpContext.Session.GetString(KeyID);
        var trueOrFalse = _trueOrFalseService.GetRandomTrueOrFalse(last_id is not null ? Guid.Parse(last_id) : null);
        HttpContext.Session.SetString(KeyID, trueOrFalse.id.ToString());

        long startTime = _timerService.GetStartTime();
        HttpContext.Session.SetString(KeyTimer, startTime.ToString());

        return trueOrFalse.statement;
    }

    private int TimeSpent()
    {
        string? timer_in_context = HttpContext.Session.GetString(KeyTimer);
        if (timer_in_context is null)
            return 0;

        long startTime = long.Parse(timer_in_context);
        long stopTime = _timerService.GetStopTime();
        double timeSpent = stopTime - startTime;

        return (int)timeSpent;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("guess/{response}")]
    public double GetRandomTrueOrFalse(bool response)
    {
        Guid id = Guid.Parse(HttpContext.Session.GetString(KeyID));
        bool isValid = _trueOrFalseService.GuessTrueOrFalse(id, response);

        int timeSpent = TimeSpent();

        int difficulty = _trueOrFalseService.GetTrueOrFalse(id).difficulty;

        User? user = _userService.GetCurrentUser(HttpContext);

        return user is not null ? _userService.UpdateScore(user.id, isValid, timeSpent, difficulty) :
                                  _userService.GetFakeScore(isValid, timeSpent, difficulty);
    }
}