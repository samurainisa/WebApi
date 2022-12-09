using WebApplication.Models;

namespace WebApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Athlete> Athletes { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Trener> Trener { get; set; }

        public DbSet<SportPlace> SportPlaces { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
    }
}