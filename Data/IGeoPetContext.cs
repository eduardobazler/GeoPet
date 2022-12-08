using Microsoft.EntityFrameworkCore;
using GeoPet.Models;

namespace GeoPet.Data
{
    public interface IGeoPetContext
    {
        public DbSet<GeoLocalization> GeoPet { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        public int SaveChanges();
    }
}

