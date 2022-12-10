using Microsoft.AspNetCore.Mvc;
using GeoPet.Services;
using GeoPet.Data;

namespace GeoPet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeoPetController : ControllerBase
    {
        public readonly IGeoPetService _service;
       // public readonly IGeoPetRepository _repository;
        public GeoPetController(IGeoPetService service)
        {
            _service = service;
           // _repository = repository;
        }

        [HttpGet]
        [Route("localization")]
        public async Task<IActionResult> FindGeoPet(string latitude, string longitude)
        {
            var result = await _service.FindGeoPet(latitude, longitude);
            if (result is false) return NotFound();
            return Ok(result);
        }
    }
}