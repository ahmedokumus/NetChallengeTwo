using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfContext : DbContext
{
    private readonly string _conString = @"Server=AHAKANOKUMUS; Database=NetChallengeTwoDbContext; Trusted_Connection=true; TrustServerCertificate=True";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_conString);
    }

    public DbSet<Carrier> Carriers { get; set; }
    public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One-to-Many relationship between Carriers and Orders
        modelBuilder.Entity<Carrier>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Carrier)
            .HasForeignKey(o => o.CarrierId);

        // One-to-Many relationship between Carrier and CarrierConfigurations
        modelBuilder.Entity<Carrier>()
            .HasOne(c => c.CarrierConfiguration)
            .WithMany(cc => cc.Carrier)
            .HasForeignKey(c => c.CarrierConfigurationId);

        // Other configurations
    }
}