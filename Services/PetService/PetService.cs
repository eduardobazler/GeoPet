using GeoPet.Controllers.TypesReq;
using GeoPet.Data;
using GeoPet.Models;

namespace GeoPet.Services.PetService;

public class PetService : IPetService
{
    private readonly IGeoPetRepository _repository;

    public PetService(IGeoPetRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Pet> CreatePet(ReqPet request)
    {
        var hasUser = _repository.GetUserById(request.UserId);

        if (hasUser is null) throw new Exception("Usuário não encontrado");
        
        var pet = new Pet()
        {
            Name = request.Name,
            UserId = request.UserId,
            Breed = (BreedEnum)request.Breed,
            Size = request.Size,
            Age = request.Age
        };

        var createdPet = await _repository.CreatePet(pet);
        return createdPet;
    }
}