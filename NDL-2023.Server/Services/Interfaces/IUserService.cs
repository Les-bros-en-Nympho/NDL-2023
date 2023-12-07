using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NDL_2023.Server.Data.Tables;

namespace NDL_2023.Server.Services.Interfaces;

public interface IUserService
{
    public User RegisterUser(string email, string passwd, string username);
    public User? ResetPassword(Guid id);
    public User? GetCurrentUser(HttpContext httpContext);
    public User? GetUser(string? email);
    public List<User> GetLeaderBoard();
}