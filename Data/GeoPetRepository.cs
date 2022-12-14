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
            return _context.User
                .Select(u => new User
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    Email = u.Email,
                    Pets = u.Pets.Select(p => new Pet
                    {
                        PetId = p.PetId,
                        Name = p.Name,
                        Breed = p.Breed,
                        Size = p.Size,
                        Age = DateTime.Now.Year - p.Age
                    })
                }).ToList();
        }

        public async Task<User> CreateUser(User user)
        {
            var createdUser = await _context.User.AddAsync(user, new CancellationToken(true));
            _context.SaveChanges();
            user.UserId = createdUser.Entity.UserId;
            return user;
        }

        public Pet GetPetById(int petId, int userId)
        {
            return _context.Pet
                .Where(p => p.UserId == userId)
                .Where(p => p.PetId == petId).FirstOrDefault();

        }
        public IEnumerable<Pet> GetPets(int userId)
        {
            return _context.Pet.Where(p => p.UserId == userId).ToList();
        }

        public async Task<Pet> CreatePet(Pet pet)
        {
            var createdPet = await _context.Pet.AddAsync(pet);
            _context.SaveChanges();
            
            return new Pet(){ PetId = createdPet.Entity.PetId};
        }
        public void DeleteUser(User users)
        {
            _context.User.Remove(users);
            _context.SaveChanges();
        }

        public void DeletePet(Pet pet)
        {
            _context.Pet.Remove(pet);
            _context.SaveChanges();
        }


        public void AddPetsToUser(Pet pet, User user)
        {
           var getPet = GetPetById(pet.PetId, user.UserId);
           var getUser = GetUserById(user.UserId);

           if (getPet is null || getUser is null) {
            throw new InvalidOperationException("Este pet ou usuário não existe");
           }

            getUser.UserId = getPet.UserId;
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

        public User FindUser(AuthUser user)
        {
            var hasUser = _context.User
                .Where(u => u.Email == user.Email)
                .Where(u => u.Password == user.Password);

            return hasUser.FirstOrDefault();
        }
    }
}
