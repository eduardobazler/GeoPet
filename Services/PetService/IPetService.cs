using GeoPet.Controllers.TypesReq;
using GeoPet.Models;

namespace GeoPet.Services.PetService;

public interface IPetService
{
    Task<Pet> CreatePet(ReqPet request);
}