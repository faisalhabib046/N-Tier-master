using System.Data.Entity;
using ThreeLayer.DAL.Entities;

namespace ThreeLayer.DAL
{
  public class AppDbContext : DbContext
  {
    public AppDbContext() : base("name=MTBC")
    {
      
    }

    public DbSet<User> Users { get; set; }
  }
}
