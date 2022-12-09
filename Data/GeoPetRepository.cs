using GeoPet.Models;

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
            return _context.Users.FirstOrDefault(y => y.UserId == userId);
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public Pet GetPetById(int PetId)
        {
            return _context.Pets.FirstOrDefault(y => y.PetId == PetId);
        }
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets.ToList();
        }
        public IEnumerable<Pet> GetPetsByUserId(int PetId)
        {
            return _context.Pets.Where(y => y.PetId == PetId);
        }
        
        public void DeleteUser(User users)
        {
            var getUser = GetPetsByUserId(users.UserId).Any();

            if(getUser) throw new InvalidOperationException("Este usuário não pode ser deletado");

            _context.Users.Remove(users);
            _context.SaveChanges();
        }
        public void AddPetsToUser(Pet pet, User user)
        {
           var getPet = GetPetById(pet.PetId);
           var getUser = GetUserById(user.UserId);

           if (getPet is null || getUser is null) {
            throw new InvalidOperationException("Este pet ou usuário não existe");
           }

            getUser.UserId = getPet.UserId;
            _context.SaveChanges();

        }
        
    }
}