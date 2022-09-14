using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataModel;

namespace API.Repository
{
  public interface UserRepository
  {
    Task<List<AppUser>> GetUsers();

    Task<AppUser> GetUser(int userId);

    Task<bool> Exists(int userId);

    Task<AppUser> UpdateUser(int userId, AppUser request);

    Task<AppUser> DeleteUser(int userId);

    Task<AppUser> AddUser(AppUser request);

  }
}