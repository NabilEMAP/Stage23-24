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
        /// <summary>
        /// Retrieves all vacations.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vacations = await _vacationsServices.GetAll();
            if (vacations == null) { return NotFound(); }
            return Ok(vacations);
        }

        // GET api/Vacations/Details
        /// <summary>
        /// Retrieves all vacations with additional details.
        /// </summary>
        /// <returns></returns>
        [HttpGet("details")]
        public async Task<IActionResult> GetAllDetails()
        {
            var vacations = await _vacationsServices.GetAllDetails();
            if (vacations == null) { return NotFound(); }
            return Ok(vacations);
        }

        // GET api/Vacations/{id}
        /// <summary>
        /// Retrieves a vacation by its ID.
        /// </summary>
        /// <param name="id">The ID of the vacation to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vacation = await _vacationsServices.GetById(id);
            if (vacation == null) { return NotFound(); }
            return Ok(vacation);
        }

        // GET api/Vacations/startdate/{startdate}
        /// <summary>
        /// Retrieves vacations by start date.
        /// </summary>
        /// <param name="startdate">The start date of the vacations to retrieve (format: YYYY-MM-DD).</param>
        /// <returns></returns>
        [HttpGet("startdate/{startdate}")]
        public async Task<IActionResult> GetVacationsByStartdate(string startdate)
        {
            var vacations = await _vacationsServices.GetVacationsByStartdate(startdate);
            if (vacations == null) { return NotFound(); }
            return Ok(vacations);
        }

        // GET api/Vacations/enddate/{enddate}
        /// <summary>
        /// Retrieves vacations by end date.
        /// </summary>
        /// <param name="enddate">The end date of the vacations to retrieve (format: YYYY-MM-DD).</param>
        /// <returns></returns>
        [HttpGet("enddate/{enddate}")]
        public async Task<IActionResult> GetVacationsByEnddate(string enddate)
        {
            var vacations = await _vacationsServices.GetVacationsByEnddate(enddate);
            if (vacations == null) { return NotFound(); }
            return Ok(vacations);
        }

        // GET api/Vacations/reason/{reason}
        /// <summary>
        /// Retrieves vacations by reason.
        /// </summary>
        /// <param name="reason">The reason for the vacations to retrieve.</param>
        /// <returns></returns>
        [HttpGet("reason/{reason}")]
        public async Task<IActionResult> GetVacationsByReason(string reason)
        {
            var vacations = await _vacationsServices.GetVacationsByReason(reason);
            if (vacations == null) { return NotFound(); }
            return Ok(vacations);
        }

        // POST api/Vacations
        /// <summary>
        /// Creates a new vacation.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVacationDTO vacation)
        {
            await _vacationsServices.Add(vacation);
            return Ok(vacation);
        }

        // PUT api/Vacations
        /// <summary>
        /// Updates an existing vacation by its ID
        /// </summary>
        /// <param name="id">The ID of the vacation to update.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Deletes a vacation by its ID.
        /// </summary>
        /// <param name="id">The ID of the vacation to delete.</param>
        /// <returns></returns>
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
