using GeoPet.Models;
using GeoPet.Services;
using Microsoft.EntityFrameworkCore;

namespace GeoPet.Data
{
    public class GeoPetRepositorys : IGeoPetRepository
    {
        private readonly IGeoPetContext _context;
        private readonly IGeoPetService _service;

        public GeoPetRepositorys(IGeoPetContext context, IGeoPetService service)
        {
            _context = context;
            _service = service;
        }

        public User GetUserById(int userId)
        {
            return _context.User.FirstOrDefault(y => y.UserId == userId);
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.User.ToList();
        }
        public Pet GetPetById(int PetId)
        {
            return _context.Pet.FirstOrDefault(y => y.PetId == PetId);
        }
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pet.ToList();
        }
        public IEnumerable<Pet> GetPetsByUserId(int PetId)
        {
            return _context.Pet.Where(y => y.PetId == PetId);
        }
        
        public void DeleteUser(User users)
        {
            var getUser = GetPetsByUserId(users.UserId).Any();

            if(getUser) throw new InvalidOperationException("Este usuário não pode ser deletado");

            _context.User.Remove(users);
            _context.SaveChanges();
        }
        public void AddPetsToUser(Pet pet, User user)
        {
           var getPet = GetPetById(pet.PetId);
           var getUser = GetUserById(user.UserId);

           if (getPet is null || getUser is null) {
            throw new InvalidOperationException("Este pet ou usuário não existe");
           }

            getUser.UserId = getPet.FK_UserId;
            _context.SaveChanges();

        }

        public async Task<GeoLocalization> AddGeoLocalPetsAsync(int PetId, string latitude, string longitude)
        {

            var getPet = GetPetById(PetId);

            if (getPet is null) throw new InvalidOperationException("Este pet não encontrado");

            var result = await _service.FindGeoPet(latitude, longitude);

            if (result is null) throw new InvalidOperationException("Este pet não possui registros");

            var geoPet = new GeoLocalization()
            {
                Id = new Guid(),
                Localization = "teste",
                OsmId = 108065,
                PetId = PetId
            };

            _context.GeoLocalization.AddRange(geoPet);

            return geoPet;

            // throw new NotImplementedException();
        }
    }
}
