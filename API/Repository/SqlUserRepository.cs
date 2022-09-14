using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DataModel;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
  public class SqlUserRepository : UserRepository
  {
    private readonly DataContext context;

    public SqlUserRepository(DataContext context)
    {
      this.context = context;
    }

    public async Task<List<AppUser>> GetUsers()
    {
      return await context.Users.ToListAsync();
    }

    public async Task<AppUser> GetUser(int userId)
    {
      return await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<bool> Exists(int userId)
    {
      // foreach x (user) in Users table, if x.id (user.id) exists //
      return await context.Users.AnyAsync(x => x.Id == userId);
    }

    public async Task<AppUser> UpdateUser(int userId, AppUser request)
    {
      var existingUser = await GetUser(userId);
      if (existingUser != null)
      {
        existingUser.FirstName = request.FirstName;
        existingUser.LastName = request.LastName;
        existingUser.UserRole = request.UserRole;
        existingUser.UserActive = request.UserActive;

        await context.SaveChangesAsync();
        return existingUser;
      }

      return null;
    }


    public async Task<AppUser> DeleteUser(int userId)
    {
      var user = await GetUser(userId);

      if (user != null)
      {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return user;
      }

      return null;
    }

    public async Task<AppUser> AddUser(AppUser request)
    {
      var user = await context.Users.AddAsync(request);

      await context.SaveChangesAsync();

      return user.Entity;
    }
  }
}