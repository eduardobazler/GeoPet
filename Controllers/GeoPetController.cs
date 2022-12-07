using Microsoft.AspNetCore.Mvc;
using GeoPet.Services;

namespace GeoPet.Controllers
{
    [ApiController]
    [Route("api/geopet")]
    public class GeoPetController : ControllerBase, IGeoPetController
    {
        public readonly IGeoPetService _service;
        public GeoPetController(IGeoPetService service)
        {
            _service = service;
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