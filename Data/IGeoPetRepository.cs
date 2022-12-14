using GeoPet.Controllers.TypesReq;
using GeoPet.Models;

namespace GeoPet.Data
{
    public interface IGeoPetRepository
    {
        User GetUserById(int userId);
        IEnumerable<User> GetUsers();
        Task<User> CreateUser(User user);
        Pet GetPetById(int petId, int userId);
        IEnumerable<Pet> GetPets(int userId);
        Task<Pet> CreatePet(Pet pet);
        void DeleteUser(User user);
        void DeletePet(Pet pet);
        void AddGeoLocalPets(int PetId, string lat, string lon);
        User FindUser(AuthUser user);
    }
}
