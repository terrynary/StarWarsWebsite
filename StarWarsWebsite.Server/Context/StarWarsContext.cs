using Microsoft.EntityFrameworkCore;
using StarWarsWebsite.Server.Models;

namespace StarWarsWebsite.Server.Context
{
    public class StarWarsContext : DbContext
    {
        public DbSet<StarShip> StarShips { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder
            .UseSqlServer(config.GetConnectionString("Star_Wars_Database"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StarShip>().HasKey(e => e.Id);
        }
    }
}
