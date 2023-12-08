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
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher<UserLogin> _passwordHasher;
    private readonly ILogger<AuthController> _logger;

    private readonly IUserService _userService;

    public AuthController(IConfiguration configuration, ILogger<AuthController> logger, IUserService userService)
    {
        _configuration = configuration;
        _passwordHasher = new PasswordHasher<UserLogin>();
        _logger = logger;
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public ActionResult Login([FromBody] UserLogin userLogin)
    {
        var user = Authenticate(userLogin);
        Console.WriteLine(user);

        if (user == null) return Unauthorized("user not found");

        var token = GenerateToken(user);
        return new OkObjectResult(new { Token = token });

    }

    [AllowAnonymous]
    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Register([FromBody] UserRegister userRegister)
    {
        try
        {
            _userService.RegisterUser(email: userRegister.Email,
                                      passwd: userRegister.Password,
                                      username: userRegister.Username);
        }
        catch (UserService.RegisterException reg_ex)
        {
            return StatusCode(reg_ex.StatusCode, new { message = reg_ex.Message });
        }
        catch (DbException)
        {
            return StatusCode(400, new { message = "Database error" });
        }
        catch
        {
            return StatusCode(400, new { message = "Unknown exception" });
        }

        return Created("User created", new { Email = userRegister.Email, Username = userRegister.Username });
    }

    private User? Authenticate(UserLogin userLogin)
    {
        var user = _userService.GetUser(userLogin.Email);

        if (user is not null)
        {
            var passwordVerification = _passwordHasher.VerifyHashedPassword(userLogin, user.password, userLogin.Password);

            switch (passwordVerification)
            {
                case PasswordVerificationResult.Failed:
                    return null;
                case PasswordVerificationResult.Success:
                    return user;
            }

            _logger.LogWarning("Password hash algorithm is deprecated and should be changed");
        }

        return user;
    }

    private string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.email),
        };

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}