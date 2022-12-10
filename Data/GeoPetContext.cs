using Microsoft.EntityFrameworkCore;
using GeoPet.Models;

namespace GeoPet.Data;

public class GeoPetContext : DbContext, IGeoPetContext
{
    public GeoPetContext(DbContextOptions<GeoPetContext> options) : base(options) { }
    public DbSet<GeoLocalization> GeoPet { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //IConfiguration configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", false, true)
            //    .Build();

            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseSqlServer(
                @"Server=127.0.0.8;Database=GeoPetDb;User=root;Password=password12!;Trusted_Connection=True;MultipleActiveResultSets=True"
               );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasData(
                new User { UserId = 1, Name = "Adriano", Email = "teste1@teste.com.br", Cep = "18037-300", Password = "123456" },
                new User { UserId = 2, Name = "Eduardo", Email = "teste2@teste.com.br", Cep = "18037-310", Password = "654321" },
                new User { UserId = 3, Name = "Astolfo", Email = "teste3@teste.com.br", Cep = "18037-320", Password = "321654" }
            );

        modelBuilder.Entity<Pet>()
            .HasData(
                new Pet { PetId = 1, Size = "Large", Age = 4, Breed = BreedEnum.Doberman, Name = "Pequenino", UserId = 3 },
                new Pet { PetId = 2, Size = "Small", Age = 2, Breed = BreedEnum.Pinscher, Name = "Zangado", UserId = 2 },
                new Pet { PetId = 3, Size = "Medium", Age = 3, Breed = BreedEnum.Pit_Bull, Name = "Pandora", UserId = 1 }
            );
    }
}

// @"Server=127.0.0.1;Database=geopetdb;User=root;Password=password12!;TrustServerCertificate=True"
// "Server=(localdb)\\msqllocaldb;Database=GeoPetDb;Trusted_Connection=True;MultipleActiveResultSets=True"
// "Server=(localdb)\\msqllocaldb;Database=GeoPetDb;User=root;Password=password12!;Trusted_Connection=True;MultipleActiveResultSets=True