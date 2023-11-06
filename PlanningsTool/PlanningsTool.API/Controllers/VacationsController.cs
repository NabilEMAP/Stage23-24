using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Vacations;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly IVacationsService _vacationsServices;

        public VacationsController(IVacationsService vacationsServices)
        {
            _vacationsServices = vacationsServices;
        }

        // GET api/Vacations
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vacations = await _vacationsServices.GetAll();
            if (vacations == null) { return NotFound(); }
            return Ok(vacations);
        }

        // GET api/Vacations/Details
        [HttpGet("details")]
        public async Task<IActionResult> GetAllDetails()
        {
            var vacations = await _vacationsServices.GetAllDetails();
            if (vacations == null) { return NotFound(); }
            return Ok(vacations);
        }

        // GET api/Vacations/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vacation = await _vacationsServices.GetById(id);
            if (vacation == null) { return NotFound(); }
            return Ok(vacation);
        }

        // GET api/Vacations/startdate/{startdate}
        [HttpGet("startdate/{startdate}")]
        public async Task<IActionResult> GetVacationsByStartdate(string startdate)
        {
            var vacations = await _vacationsServices.GetVacationsByStartdate(startdate);
            if (vacations == null) { return NotFound(); }
            return Ok(vacations);
        }

        // GET api/Vacations/enddate/{enddate}
        [HttpGet("enddate/{enddate}")]
        public async Task<IActionResult> GetVacationsByEnddate(string enddate)
        {
            var vacations = await _vacationsServices.GetVacationsByEnddate(enddate);
            if (vacations == null) { return NotFound(); }
            return Ok(vacations);
        }

        // GET api/Vacations/reden/{reden}
        [HttpGet("reden/{reden}")]
        public async Task<IActionResult> GetVacationsByReason(string reason)
        {
            var vacations = await _vacationsServices.GetVacationsByReason(reason);
            if (vacations == null) { return NotFound(); }
            return Ok(vacations);
        }

        // POST api/Vacations
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVacationDTO vacation)
        {
            try
            {
                await _vacationsServices.Add(vacation);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(vacation);
        }

        // PUT api/Vacations
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateVacationDTO vacation)
        {
            if (vacation == null)
            {
                return NotFound();
            }
            await _vacationsServices.Update(id, vacation);
            return Ok(vacation);
        }

        // DELETE api/Vacations
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vacation = await _vacationsServices.GetById(id);
            if (vacation == null)
            {
                return NotFound();
            }
            await _vacationsServices.Delete(id);
            return NoContent();
        }
    }
}
