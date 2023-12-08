using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using NDL_2023.Server.Data;
using NDL_2023.Server.Data.Tables;
using NDL_2023.Server.Services.Interfaces;

namespace NDL_2023.Server.Services.Class;

public class UserService: IUserService
{
    private readonly EntityContext _context;

    public UserService(EntityContext context)
    {
        _context = context;
    }

    public class RegisterException : Exception
    {
        public int StatusCode { get; }
        public RegisterException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
    
    private User RegisterUserWithoutSaving(string email, string passwd, string username)
    {
        User? user = _context.Users.FirstOrDefault(x => x.email == email);

        if (user is not null)
            throw new RegisterException(409, "User already exits");
        
        if (passwd.Length < 8)
            throw new RegisterException(403, "Password is too short");

        var registered_user = new User
        {
            id = Guid.NewGuid(),
            email = email,
            username = username,
            score = 0
        };

        var hashedPassword = new PasswordHasher<User>().HashPassword(registered_user, passwd);

        registered_user.password = hashedPassword;

        _context.Users.Add(registered_user);

        return registered_user;
    }
    
    public User RegisterUser(string email, string passwd, string username)
    {
        var registered_user = RegisterUserWithoutSaving(email, passwd, username);

        _context.SaveChanges();

        return registered_user;
    }

    public User? GetCurrentUser(HttpContext httpContext)
    {
        ClaimsIdentity? identity = httpContext.User.Identity as ClaimsIdentity;
        Claim? email = identity?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email);

        return GetUser(email?.Value);
    }

    public User? GetUser(string? email)
    {
        return email is not null ? _context.Users.FirstOrDefault(x => x.email == email) :
            null;
    }

    private double GetFactorScoreTimeSpent(int millisecondsSpended)
    {
        double time_max = 60 * 1000;

        return millisecondsSpended > time_max ? 0 :
                                                time_max - millisecondsSpended;
    }

    private double CalcScore(bool is_valid, int millisecondsSpended, int difficulty)
    {
        double score = 40 + new Random().Next(-10, 20);

        if (millisecondsSpended < 400)
            score = -score;
        else
            score += GetFactorScoreTimeSpent(millisecondsSpended) / 1000;

        if (!is_valid)
            score = score < 0 ? score - Math.Round(score / 2) :
                                -score - Math.Round(score / 2);

        if (difficulty > 0)
            score *= double.Parse($"1.{difficulty}");

        return score;
    }

    public double GetFakeScore(bool is_valid, int millisecondsSpended, int difficulty)
    {
        return CalcScore(is_valid, millisecondsSpended, difficulty);
    }

    public double UpdateScore(Guid id, bool is_valid, int millisecondsSpended, int difficulty)
    {
        User user = _context.Users.First(u => u.id == id);

        double score = CalcScore(is_valid, millisecondsSpended, difficulty);

        user.score += score;

        _context.Update(user);
        _context.SaveChanges();

        return score;
    }

    public List<User> GetLeaderBoard(int nbUsers)
    {
        return _context.Users.OrderByDescending(user => user.score).Take(nbUsers).ToList();
    }
}