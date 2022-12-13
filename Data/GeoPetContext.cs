using Microsoft.EntityFrameworkCore;
using GeoPet.Models;

namespace GeoPet.Data;

public class GeoPetContext : DbContext, IGeoPetContext
{
    public GeoPetContext(DbContextOptions<GeoPetContext> options) : base(options) { }
    public DbSet<GeoLocalization> GeoLocalization { get; set; }
    public DbSet<Pet> Pet { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(@"
                    Server=tcp:geopetadmin.database.windows.net,1433;
                    Initial Catalog=GeoPet;
                    Persist Security Info=False;
                    User ID=geopetadmin;
                    Password=GeoPet_1;
                    MultipleActiveResultSets=False;
                    Encrypt=True;
                    TrustServerCertificate=False;
                    Connection Timeout=30;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>()
            .HasOne(b => b.User)
            .WithMany(p => p.Pet)
            .HasForeignKey(b => b.FK_UserId);
    }
}

// @"Server=127.0.0.1;Database=geopetdb;User=root;Password=password12!;TrustServerCertificate=True"
// "Server=(localdb)\\msqllocaldb;Database=GeoPetDb;Trusted_Connection=True;MultipleActiveResultSets=True"
// "Server=(localdb)\\msqllocaldb;Database=GeoPetDb;User=root;Password=password12!;Trusted_Connection=True;MultipleActiveResultSets=True