using Microsoft.EntityFrameworkCore;

public class DBContext : DbContext
{
    public DbSet<ComicBook> ComicBooks { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalDetail> RentalDetails { get; set; }

    public DBContext(DbContextOptions<DBContext> options) : base(options) { }
}
