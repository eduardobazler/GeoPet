using System.Security.Claims;
using GeoPet.Controllers.TypesReq;
using Microsoft.AspNetCore.Mvc;
using GeoPet.Services;
using GeoPet.Data;
using GeoPet.Models;
using GeoPet.Services.PetService;
using GeoPet.Services.UserService;
using GeoPet.Utils;
using Microsoft.AspNetCore.Authorization;

namespace GeoPet.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api")]
    public class BaseController : ControllerBase
    {
        public readonly IGeoPetRepository _repository;

        private readonly IUserService _userService;
        private readonly IPetService _petService;
        
        //public readonly IGeoPetService _service;

        public BaseController(IGeoPetRepository repository, IUserService userService, IPetService petService)
        {
            _repository = repository;
            _userService = userService;
            _petService = petService;
        }
        
        /// <summary> This function return a user</summary>
        /// <param name="id"> a user id</param>
        /// <returns> a user</returns>
        [HttpGet("user/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_repository.GetUserById(id));
        }

        /// <summary> This function return a list of users</summary>
        /// <returns> a user list</returns>
        [HttpGet("user")]
        public IActionResult GetUsers()
        {
            return Ok(_repository.GetUsers());
        }

        [AllowAnonymous]
        [HttpPost("user")]
        public async Task<ActionResult> CreateUser(ReqUser request)
        {
            try
            {
                await _userService.CreateUser(request);
                return Ok("Created User");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
            
        }
        
        /// <summary> This function deletes a user</summary>
        /// <param name="id"> a user id</param>
        /// <returns> a user</returns>
        [HttpDelete("user")]
        public IActionResult DeleteChannel()
        {
            var userId = GetUserIdToken();

            if (userId is null) return Unauthorized();

            var user = _repository.GetUserById(Int32.Parse(userId));
            if (user is null)
            {
                return NotFound();
            }
            _repository.DeleteUser(user);
            return Ok(user);
        }

         /// <summary> This function list a pet</summary>
        /// <param name="id"> a pet id</param>
        /// <returns> a pet list</returns>
        [HttpGet("pet/{id}")]

         public IActionResult GetPetById(int id)
        {
            var userId = GetUserIdToken();

            if (userId is null) return Unauthorized();
            
            var pet = _repository.GetPetById(id, Int32.Parse(userId));
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        /// <summary> This function return a list of pets</summary>
        /// <returns> a pet list</returns>
        [HttpGet("pet")]
        public IActionResult GetPets()
        {
            var userId = GetUserIdToken();

            if (userId is null) return Unauthorized();
            
            return Ok(_repository.GetPets(Int32.Parse(userId)));
        }
        
        [HttpPost("pet")]
        public async Task<ActionResult> CreatePet(ReqPet request)
        {
            var id = GetUserIdToken();

            if (id is null) return Unauthorized();
            
            var pet = new Pet()
            {
                Name = request.Name,
                UserId = Int32.Parse(id),
                Breed = (BreedEnum)request.Breed,
                Size = request.Size,
                Age = request.Age
            };
            
            try
            {
                await _petService.CreatePet(pet);
                return Ok("Created Pet");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
            
        }

        [HttpDelete("pet")]
        public ActionResult DeletePet(int petId)
        {
            var id = GetUserIdToken();
            
            if (id is null) return Unauthorized();
            
            try
            {
                 _petService.DeletePet(petId, Int32.Parse(id));
                return Ok("Created Pet");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
    
        }

        private string GetUserIdToken()
        {
            var userClaims = HttpContext.User.Identities.FirstOrDefault();
            var userId = userClaims.FindFirst(x => x.Type == "Id")?.Value;

            return userId;
        }
    }
}