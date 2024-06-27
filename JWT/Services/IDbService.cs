using CodeFirst.Models;

namespace CodeFirst.Services;

public interface IDbService
{

    Task RegisterUser(User user);
    Task<User> GetUser(string login);
    Task SetUserToken(User u, string token);
    Task<User> GetUserByToken(string token);
}