using Microsoft.EntityFrameworkCore;
using GeoPet.Models;

namespace GeoPet.Data;

public class GeoPetContext : DbContext, IGeoPetContext
{
    public GeoPetContext(DbContextOptions<GeoPetContext> options) : base(options) { }
    public GeoPetContext() { }
    public DbSet<GeoLocalization> GeoPet { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Server=127.0.0.1;Database=geo-pet;User=SA;Password=password12!;TrustServerCertificate=True");
        }
    }
}
