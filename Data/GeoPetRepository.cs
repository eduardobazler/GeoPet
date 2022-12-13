using System.ComponentModel.DataAnnotations;
using GeoPet.Controllers.TypesReq;
using GeoPet.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoPet.Data
{
    public class GeoPetRepositorys : IGeoPetRepository
    {
        private readonly IGeoPetContext _context;
        public GeoPetRepositorys(IGeoPetContext context)
        {
            _context = context;
        }

        public User GetUserById(int userId)
        {
            return _context.User.FirstOrDefault(y => y.UserId == userId);
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.User.ToList();
        }

        public async Task<User> CreateUser(User user)
        {
            var createdUser = await _context.User.AddAsync(user, new CancellationToken(true));
            Console.WriteLine(createdUser);
            _context.SaveChanges();
            return createdUser.Entity;
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

        public void AddGeoLocalPets(int PetId, string lan, string lon)
        {
            //var getPet = GetPetById(PetId);
            //if (getPet is null) throw new InvalidOperationException("Este pet não existe");

            //_context.GeoLocalization.Add(getPet);
            //_context.SaveChanges();

            throw new NotImplementedException();

        }
    }
}
