using Microsoft.EntityFrameworkCore;
using SalesforceConnectOData.Models;

namespace SalesforceConnectOData.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Account> Accounts => Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(
            new Account { Id = 1,  Name = "Acme Corporation",     Email = "contact@acme.com",       Phone = "555-0101", CreatedAt = new DateTime(2024, 1, 15) },
            new Account { Id = 2,  Name = "Globex Industries",    Email = "info@globex.com",        Phone = "555-0102", CreatedAt = new DateTime(2024, 2, 20) },
            new Account { Id = 3,  Name = "Initech LLC",          Email = "hello@initech.com",      Phone = "555-0103", CreatedAt = new DateTime(2024, 3, 10) },
            new Account { Id = 4,  Name = "Umbrella Corp",        Email = "sales@umbrella.com",     Phone = "555-0104", CreatedAt = new DateTime(2024, 4, 5) },
            new Account { Id = 5,  Name = "Stark Enterprises",    Email = "tony@stark.com",         Phone = "555-0105", CreatedAt = new DateTime(2024, 5, 12) },
            new Account { Id = 6,  Name = "Wayne Industries",     Email = "bruce@wayne.com",        Phone = "555-0106", CreatedAt = new DateTime(2024, 6, 18) },
            new Account { Id = 7,  Name = "Oscorp",               Email = "norman@oscorp.com",      Phone = "555-0107", CreatedAt = new DateTime(2024, 7, 22) },
            new Account { Id = 8,  Name = "Cyberdyne Systems",    Email = "info@cyberdyne.com",     Phone = "555-0108", CreatedAt = new DateTime(2024, 8, 30) },
            new Account { Id = 9,  Name = "Wonka Industries",     Email = "willy@wonka.com",        Phone = "555-0109", CreatedAt = new DateTime(2024, 9, 14) },
            new Account { Id = 10, Name = "Dunder Mifflin",       Email = "michael@dundermifflin.com", Phone = "555-0110", CreatedAt = new DateTime(2024, 10, 1) },
            new Account { Id = 11, Name = "Pied Piper",           Email = "richard@piedpiper.com",  Phone = "555-0111", CreatedAt = new DateTime(2024, 11, 8) },
            new Account { Id = 12, Name = "Hooli",                Email = "gavin@hooli.com",        Phone = "555-0112", CreatedAt = new DateTime(2024, 12, 25) }
        );
    }
}
