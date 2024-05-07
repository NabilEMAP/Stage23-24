using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftTypesController : ControllerBase
    {
        private readonly IShiftTypesService _shiftTypesServices;

        public ShiftTypesController(IShiftTypesService shiftTypesServices)
        {
            _shiftTypesServices = shiftTypesServices;
        }

        // GET api/ShiftTypes
        /// <summary>
        /// Retrieves all shift types.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shiftTypes = await _shiftTypesServices.GetAll();
            if (shiftTypes == null) { return NotFound(); }
            return Ok(shiftTypes);
        }

        // GET api/ShiftTypes/{id}
        /// <summary>
        /// Retrieves a shift type by its ID.
        /// </summary>
        /// <param name="id">The ID of the shift type to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shiftType = await _shiftTypesServices.GetById(id);
            if (shiftType == null) { return NotFound(); }
            return Ok(shiftType);
        }

        // GET api/ShiftTypes/name/{name}
        /// <summary>
        /// Retrieves shift types by name.
        /// </summary>
        /// <param name="name">The name of the shift type to search for.</param>
        /// <returns></returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetShiftTypesByNaam(string name)
        {
            var shiftTypes = await _shiftTypesServices.GetShiftTypesByName(name);
            if (shiftTypes == null) { return NotFound(); }
            return Ok(shiftTypes);
        }
    }
}
