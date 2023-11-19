using Microsoft.EntityFrameworkCore;

namespace SomeWarehouse.WarehouseDB
{
    public class WarehoudeDbContext : DbContext
    {
        private string _connectionstring = "Server=(localdb)\\mssqllocaldb;Database=WarehoudeDb;Trusted_Connection=True;";

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Alloy> Alloys { get; set; }

        public DbSet<Shelf> Shelfs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<Shelf>()
                .Property(d => d.numberOfShelf)
                .IsRequired()
                .HasMaxLength(30);
                

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionstring);
        }
    }
}
