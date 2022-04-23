using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Mod.DataModels;

namespace Mod.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DatabaseContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RPMod;Username=postgres;Password=890142");
            optionsBuilder.LogTo(NAPI.Util.ConsoleOutput);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Account>().Property(e => e.Password).
        }
    }
}