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
        /// <summary>
        /// Retrieves all regime types.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regimeTypes = await _regimeTypesServices.GetAll();
            if (regimeTypes == null) { return NotFound(); }
            return Ok(regimeTypes);
        }

        // GET api/RegimeTypes/{id}
        /// <summary>
        /// Retrieves a regime type by its ID.
        /// </summary>
        /// <param name="id">The ID of the regime type to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var regimeType = await _regimeTypesServices.GetById(id);
            if (regimeType == null) { return NotFound(); }
            return Ok(regimeType);
        }

        // GET api/RegimeTypes/name/{name}
        /// <summary>
        /// Retrieves regime types by name.
        /// </summary>
        /// <param name="name">The name of the regime type to search for.</param>
        /// <returns></returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetRegimeTypesByName(string name)
        {
            var regimeTypes = await _regimeTypesServices.GetRegimeTypesByName(name);
            if (regimeTypes == null) { return NotFound(); }
            return Ok(regimeTypes);
        }

        // GET api/RegimeTypes/countHours/{countHours}
        /// <summary>
        /// Retrieves regime types by count of hours.
        /// </summary>
        /// <param name="countHours">The count of hours of the regime type to search for.</param>
        /// <returns></returns>
        [HttpGet("countHours/{countHours}")]
        public async Task<IActionResult> GetRegimeTypesByCountHours(string countHours)
        {
            var regimeTypes = await _regimeTypesServices.GetRegimeTypesByCountHours(countHours);
            if (regimeTypes == null) { return NotFound(); }
            return Ok(regimeTypes);
        }
    }
}
