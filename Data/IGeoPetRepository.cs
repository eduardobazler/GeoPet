using GeoPet.Models;
using GeoPet.Services;

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
        Task<Object> AddGeoLocalPetsAsync(int PetId, string lat, string lon);
    }
}
