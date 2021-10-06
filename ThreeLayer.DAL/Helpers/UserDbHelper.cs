using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ThreeLayer.DAL.Entities;

namespace ThreeLayer.DAL.Helpers
{
  public class UserDbHelper
  {
    public async Task<bool> CreateUser(User user)
    {
      using (var dbContext = new AppDbContext())
      {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
      }

      return true;
    }

    public async Task<bool> UpdateUser(User user)
    {
      using (var dbContext = new AppDbContext())
      {
        dbContext.Users.Add(user);
        dbContext.Entry(user).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
      }

      return true;
    }

    public async Task<User> GetUser(int id)
    {
      using (var dbContext = new AppDbContext())
      {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
      }
    }

    public async Task<List<User>> List()
    {
      using (var dbContext = new AppDbContext())
      {
        return await dbContext.Users.ToListAsync();
      }
    }

    public async Task<User> GetUserByUsernamePassword(string username, string password)
    {
      using (var dbContext = new AppDbContext())
      {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        return user;
      }
    }

    public async Task<bool> DeleteUser(int id)
    {
      using (var dbContext = new AppDbContext())
      {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
          return false;
        }

        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
        return true;
      }
    }
  }
}
