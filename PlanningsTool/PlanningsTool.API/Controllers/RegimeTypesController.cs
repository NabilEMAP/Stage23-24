using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegimeTypesController : ControllerBase
    {
        private readonly IRegimeTypesService _regimeTypesServices;

        public RegimeTypesController(IRegimeTypesService regimeTypesServices)
        {
            _regimeTypesServices = regimeTypesServices;
        }

        // GET api/RegimeTypes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regimeTypes = await _regimeTypesServices.GetAll();
            if (regimeTypes == null) { return NotFound(); }
            return Ok(regimeTypes);
        }

        // GET api/RegimeTypes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var regimeType = await _regimeTypesServices.GetById(id);
            if (regimeType == null) { return NotFound(); }
            return Ok(regimeType);
        }

        // GET api/RegimeTypes/name/{name}
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetRegimeTypesByName(string name)
        {
            var regimeTypes = await _regimeTypesServices.GetRegimeTypesByName(name);
            if (regimeTypes == null) { return NotFound(); }
            return Ok(regimeTypes);
        }

        // GET api/RegimeTypes/countHours/{countHours}
        [HttpGet("countHours/{countHours}")]
        public async Task<IActionResult> GetRegimeTypesByCountHours(string countHours)
        {
            var regimeTypes = await _regimeTypesServices.GetRegimeTypesByCountHours(countHours);
            if (regimeTypes == null) { return NotFound(); }
            return Ok(regimeTypes);
        }
    }
}
