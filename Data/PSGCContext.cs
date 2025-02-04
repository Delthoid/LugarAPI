using Microsoft.EntityFrameworkCore;

namespace LugarAPI.Data
{
    public class PSGCContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MyServer; Database=MyDatabase; Trusted_Connection=True;");
        }
    }
}
