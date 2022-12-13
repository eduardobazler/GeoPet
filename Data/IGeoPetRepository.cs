using GeoPet.Controllers.TypesReq;
using GeoPet.Models;

namespace GeoPet.Data
{
    public interface IGeoPetRepository
    {
        User GetUserById(int userId);
        IEnumerable<User> GetUsers();
        Task<User> CreateUser(User user);
        Pet GetPetById(int PetId);
        IEnumerable<Pet> GetPets();
        IEnumerable<Pet> GetPetsByUserId(int userId);
        void DeleteUser(User user);
        void AddPetsToUser(Pet Pets, User user);
        void AddGeoLocalPets(int PetId, string lat, string lon);
    }
}
