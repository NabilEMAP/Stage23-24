using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.NurseShifts;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseShiftsController : Controller
    {
        private readonly INurseShiftsService _nurseShiftsServices;

        public NurseShiftsController(INurseShiftsService nurseShiftsServices)
        {
            _nurseShiftsServices = nurseShiftsServices;
        }

        // GET api/NurseShifts
        /// <summary>
        /// Retrieves all nurse shifts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nurseShifts = await _nurseShiftsServices.GetAll();
            if (nurseShifts == null) { return NotFound(); }
            return Ok(nurseShifts);
        }

        // GET api/NurseShifts/{id}
        /// <summary>
        /// Retrieves a nurse shift by its ID.
        /// </summary>
        /// <param name="id">The ID of the nurse shift to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nurseShift = await _nurseShiftsServices.GetById(id);
            if (nurseShift == null) { return NotFound(); }
            return Ok(nurseShift);
        }

        // GET api/NurseShifts/date/{date}
        /// <summary>
        /// Retrieves nurse shifts by date.
        /// </summary>
        /// <param name="date">The date of the nurse shifts to retrieve (format: YYYY-MM-DD).</param>
        /// <returns></returns>
        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetNurseShiftsByDatum(string date)
        {
            var nurseShifts = await _nurseShiftsServices.GetNurseShiftsByDate(date);
            if (nurseShifts == null) { return NotFound(); }
            return Ok(nurseShifts);
        }

        // POST api/NurseShifts
        /// <summary>
        /// Creates a new nurse shift.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNurseShiftDTO nurseShift)
        {
            await _nurseShiftsServices.Add(nurseShift);
            return Ok(nurseShift);
        }

        // PUT api/NurseShifts
        /// <summary>
        /// Updates an existing nurse shift by its ID.
        /// </summary>
        /// <param name="id">The ID of the nurse shift to update.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateNurseShiftDTO nurseShift)
        {
            if (nurseShift == null)
            {
                return NotFound();
            }
            await _nurseShiftsServices.Update(id, nurseShift);
            return Ok(nurseShift);
        }

        // DELETE api/NurseShifts
        /// <summary>
        /// Deletes a nurse shift by its ID.
        /// </summary>
        /// <param name="id">The ID of the nurse shift to delete.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var nurseShift = await _nurseShiftsServices.GetById(id);
            if (nurseShift == null)
            {
                return NotFound();
            }
            await _nurseShiftsServices.Delete(id);
            return NoContent();
        }
    }
}
