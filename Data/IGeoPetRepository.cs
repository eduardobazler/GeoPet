using GeoPet.Models;

namespace GeoPet.Data
{
    public interface IGeoPetRepository
    {
        User GetUserById(int userId);
        IEnumerable<User> GetUsers();
        Pet GetPetById(int PetId);
        IEnumerable<Pet> GetPets();
        IEnumerable<Pet> GetPetsByUserId(int userId);
        void DeleteUser(User user);
        void AddPetsToUser(Pet Pets, User user);
        Task<GeoLocalization> AddGeoLocalPetsAsync(int PetId, string lat, string lon);
    }
}
