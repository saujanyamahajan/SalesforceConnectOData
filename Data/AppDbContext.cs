using Microsoft.EntityFrameworkCore;
using SalesforceConnectOData.Models;

namespace SalesforceConnectOData.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<Account> Accounts => Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.ToTable("Asset");
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");
        });
    }
}