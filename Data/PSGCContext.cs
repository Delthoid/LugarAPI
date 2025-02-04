using LugarAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LugarAPI.Data
{
    public class PSGCContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SERVER;Database=PSGC_DB;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(r =>
            {
                r.HasNoKey();
            });
        }
    }
}
