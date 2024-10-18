using Microsoft.EntityFrameworkCore;
using moviepoint.Models;

namespace moviepoint.data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> movies { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Cinema> cinemas { get; set; }
        public DbSet<Actor> actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build()
                .GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(builder);
        }
    }
}