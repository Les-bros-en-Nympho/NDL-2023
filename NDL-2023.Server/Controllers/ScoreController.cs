using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NDL_2023.Server.Data.Tables;
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
    private const string KeyID = "__ID_KEY__";

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
}