using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Restaurant
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionstring = "Server=(localdb)\\mssqllocaldb;Database=RestaurantDbmode;Trusted_Connection=True;";
        public DbSet<Restaurante> Restaurants { get; set; }

        public DbSet<Address> Addreses { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurante>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionstring);
        }
    }
}
