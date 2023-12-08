using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NDL_2023.Server.Data.Tables;
using NDL_2023.Server.Form;
using NDL_2023.Server.Services.Class;
using NDL_2023.Server.Services.Interfaces;

namespace NDL_2023.Server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ScoreController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITimerService _timerService;
    private readonly ITrueOrFalseService _trueOrFalseService;
    private const string KeyTimer = "__TIMER_KEY__";

    public ScoreController(ITimerService timerService, IUserService userService, ITrueOrFalseService trueOrFalseService)
    {
        _timerService = timerService;
        _userService = userService;
        _trueOrFalseService = trueOrFalseService;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("leaderboard/{nb_players}")]
    public List<User> GetLeaderboard(int nb_players)
    {
        return _userService.GetLeaderBoard(nb_players);
    }

    private int TimeSpent()
    {
        string? timer_in_context = HttpContext.Session.GetString(KeyTimer);
        if (timer_in_context is null)
            return 0;

        long startTime = long.Parse(timer_in_context);
        long stopTime = _timerService.GetStopTime();
        double milliTimeSpent = startTime - stopTime;

        return (int)Math.Round(milliTimeSpent);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("fakescore/{id_true_or_false}")]
    public double GetFakeScore(Guid id_true_or_false)
    {
        int timeSpent = TimeSpent();

        int difficulty = _trueOrFalseService.GetTrueOrFalse(id_true_or_false).difficulty;

        return _userService.GetFakeScore(timeSpent, difficulty);
    }

    [Authorize]
    [HttpGet]
    [Route("updatescore/{id_user}/{id_true_or_false}")]
    public double UpdateScore(Guid id_user, Guid id_true_or_false)
    {
        int timeSpent = TimeSpent();

        int difficulty = _trueOrFalseService.GetTrueOrFalse(id_true_or_false).difficulty;

        return _userService.UpdateScore(id_user, timeSpent, difficulty);
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