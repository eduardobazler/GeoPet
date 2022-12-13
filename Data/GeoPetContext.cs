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
                .EnableSensitiveDataLogging()
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
