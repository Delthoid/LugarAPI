using LugarAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LugarAPI.Data
{
    public class PSGCContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Barangay> Barangays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SERVER;Database=PSGC_DB;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(r => r.HasNoKey());
            modelBuilder.Entity<Province>(r => r.HasNoKey()); 
            modelBuilder.Entity<City>(r => r.HasNoKey());
            modelBuilder.Entity<Municipality>(r => r.HasNoKey());
            modelBuilder.Entity<Barangay>(r => r.HasNoKey());
        }
    }
}
