using Microsoft.AspNetCore.Mvc;
using GeoPet.Services;
using GeoPet.Data;
using QRCoder;
using System.Drawing.Imaging;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace GeoPet.Controllers
{
    [ApiController]
    [Route("api")]
    public class BaseController : ControllerBase
    {
        public readonly IGeoPetRepository _repository;
        // public readonly IGeoPetService _service;

        public BaseController(IGeoPetRepository repository)
        {
            _repository = repository;
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

        /// <summary> This function return a list of pets of user</summary>
        /// <param name="userId"> a user id</param>
        /// <returns> a pet list</returns>
        [HttpGet("user/{id}/pet")]
        public IActionResult GetPetsByUser(int userId)
        {
            return Ok(_repository.GetPetsByUserId(userId));
        }

        /// <summary> This function deletes a user</summary>
        /// <param name="id"> a user id</param>
        /// <returns> a user</returns>
        [HttpDelete("user/{id}")]
        public IActionResult DeleteChannel(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
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
            var pet = _repository.GetPetById(id);
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
            return Ok(_repository.GetPets());
        }


        /// <summary> This function add a pet to a user</summary>
        /// <param name="userId"> a user id</param>
        /// <param name="petId"> a pet id</param>
        /// <returns> a video</returns>
        [HttpPost("user/{userId}/pet/{petId}")]
        public IActionResult AddPetsToUser(int userId, int petId)
        {
            var user = _repository.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            var pet = _repository.GetPetById(petId);
            if (pet == null)
            {
                return NotFound();
            }
            _repository.AddPetsToUser(pet, user);
            return Ok(pet);
        }

        /// <summary> This function add a localization to a pet</summary>
        /// <param name="petId"> a pet id</param>
        /// <param name="latitude"> a latitude</param>
        /// <param name="longitude"> a longitude</param>
        /// <returns> a localization</returns>
        [HttpPost("pet/{petId}/localization")]
        public async Task<IActionResult> AddGeoLocalPetsAsync(int petId, string latitude, string longitude)
        {

            var geoPet = await _repository.AddGeoLocalPetsAsync(petId, latitude, longitude);

            if (geoPet == null) return NotFound();

            return Ok(geoPet);

        }

        /// <summary> This function generate a QRCode to a user</summary>
        /// <param name="petId"> a pet id</param>
        /// <returns> a qrcode</returns>
        [HttpGet("/GenerateQrCode/{petId}")]
        public IActionResult GenerateQrCode(int petId)
        {

            var qrCode = _repository.GenerateQrCode(petId);

            if (qrCode == null) return NotFound();

            return Ok(qrCode);

        }
    }
}

// http://api.qrserver.com/v1/create-qr-code/?data=HelloWorld!&size=100x100