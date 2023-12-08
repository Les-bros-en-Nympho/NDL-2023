using NDL_2023.Server.Data.Tables;

namespace NDL_2023.Server.Services.Interfaces;

public interface IUserService
{
    public User RegisterUser(string email, string passwd, string username);
    public User? GetCurrentUser(HttpContext httpContext);
    public User? GetUser(string? email);
    public double GetFakeScore(bool is_valid, int millisecondsSpended, int difficulty);
    public double UpdateScore(Guid id, bool is_valid, int millisecondsSpended, int difficulty);
    public List<User> GetLeaderBoard(int nbUsers);
}