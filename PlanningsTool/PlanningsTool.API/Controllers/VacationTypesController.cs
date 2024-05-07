using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationTypesController : ControllerBase
    {
        private readonly IVacationTypesService _vacationTypesServices;

        public VacationTypesController(IVacationTypesService vacationTypesServices)
        {
            _vacationTypesServices = vacationTypesServices;
        }

        // GET api/VacationTypes
        /// <summary>
        /// Retrieves all vacation types.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vacationTypes = await _vacationTypesServices.GetAll();
            if (vacationTypes == null) { return NotFound(); }
            return Ok(vacationTypes);
        }

        // GET api/VacationTypes/{id}
        /// <summary>
        /// Retrieves a vacation type by its ID.
        /// </summary>
        /// <param name="id">The ID of the vacation type to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vacationType = await _vacationTypesServices.GetById(id);
            if (vacationType == null) { return NotFound(); }
            return Ok(vacationType);
        }

        // GET api/VacationTypes/name/{name}
        /// <summary>
        /// Retrieves vacation types by name.
        /// </summary>
        /// <param name="name">The name of the vacation type to search for.</param>
        /// <returns></returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetVacationTypesByNaam(string name)
        {
            var vacationTypes = await _vacationTypesServices.GetVacationTypesByName(name);
            if (vacationTypes == null) { return NotFound(); }
            return Ok(vacationTypes);
        }
    }
}
