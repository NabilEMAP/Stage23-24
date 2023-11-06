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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vacationTypes = await _vacationTypesServices.GetAll();
            if (vacationTypes == null) { return NotFound(); }
            return Ok(vacationTypes);
        }

        // GET api/VacationTypes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vacationType = await _vacationTypesServices.GetById(id);
            if (vacationType == null) { return NotFound(); }
            return Ok(vacationType);
        }

        // GET api/VacationTypes/name/{name}
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetVacationTypesByNaam(string name)
        {
            var vacationTypes = await _vacationTypesServices.GetVacationTypesByName(name);
            if (vacationTypes == null) { return NotFound(); }
            return Ok(vacationTypes);
        }
    }
}
