using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeLayer.DAL.Entities;
using ThreeLayer.DAL.Helpers;

namespace ThreeLayer.BAL
{
  public class UserService
  {
    private readonly UserDbHelper _dbHelper;

    public UserService()
    {
      _dbHelper = new UserDbHelper();
    }

    public async Task<User> GetUserById(int id)
    {
      return await _dbHelper.GetUser(id);
    }

    public async Task<bool> AddUser(User user)
    {
      var doesUserExist = await _dbHelper.GetUserByUsernamePassword(user.Username, user.Password);
      if (doesUserExist != null)
      {
        return false;
      }

      return await _dbHelper.CreateUser(user);
    }

    public async Task<bool> UpdateUser(User user)
    {
      return await _dbHelper.UpdateUser(user);
    }

    public async Task<User> AuthenticateUser(string username, string password)
    {
      return await _dbHelper.GetUserByUsernamePassword(username, password);
    }

    public async Task<List<User>> ListUsers()
    {
      return await _dbHelper.List();
    }

    public async Task<bool> DeleteUser(int id)
    {
      return await _dbHelper.DeleteUser(id);
    }
  }
}
