﻿using CodeFirst.Data;
using CodeFirst.Helpers;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Services;

public class DbService : IDbService
{
    public AppDbContext Context;

    public DbService(AppDbContext context)
    {
        Context = context;
    }
    
    public async Task RegisterUser(User user)
    {
        await Context.Users.AddAsync(user);
        await Context.SaveChangesAsync();
    }
    
    public async Task<User> GetUser(string name)
    {
        return await Context.Users.FirstOrDefaultAsync(u => u.Login == name );
    }

    public async Task SetUserToken(User u, string token)
    {
        u.RefreshToken = token;
        await Context.SaveChangesAsync();
    }

    public async Task<User> GetUserByToken(string token)
    {
        return await Context.Users.FirstOrDefaultAsync(u => u.RefreshToken == token);
    }
}