using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
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

    public User? ResetPassword(Guid id)
    {
        throw new NotImplementedException();
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

    public List<User> GetLeaderBoard()
    {
        throw new NotImplementedException();
    }
}