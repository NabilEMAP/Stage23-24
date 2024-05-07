using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Shifts;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftsService _shiftsServices;

        public ShiftsController(IShiftsService shiftsServices)
        {
            _shiftsServices = shiftsServices;
        }

        // GET api/Shifts
        /// <summary>
        /// Retrieves all shifts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shifts = await _shiftsServices.GetAll();
            if (shifts == null) { return NotFound(); }
            return Ok(shifts);
        }

        // GET api/Shifts/{id}
        /// <summary>
        /// Retrieves a shift by its ID
        /// </summary>
        /// <param name="id">The ID of the shift to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shift = await _shiftsServices.GetById(id);
            if (shift == null) { return NotFound(); }
            return Ok(shift);
        }

        // GET api/Shifts/starttime/{starttime}
        /// <summary>
        /// Retrieves shifts by start time.
        /// </summary>
        /// <param name="starttime">The start time of the shifts to retrieve (format: HH:mm:ss).</param>
        /// <returns></returns>
        [HttpGet("starttime/{starttime}")]
        public async Task<IActionResult> GetShiftsByStarttime(string starttime)
        {
            var shifts = await _shiftsServices.GetShiftsByStarttime(starttime);
            if (shifts == null) { return NotFound(); }
            return Ok(shifts);
        }

        // GET api/Shifts/endtime/{endtime}
        /// <summary>
        /// Retrieves shifts by end time.
        /// </summary>
        /// <param name="endtime">The end time of the shifts to retrieve (format: HH:mm:ss).</param>
        /// <returns></returns>
        [HttpGet("endtime/{endtime}")]
        public async Task<IActionResult> GetShiftsByEndtime(string endtime)
        {
            var shifts = await _shiftsServices.GetShiftsByEndtime(endtime);
            if (shifts == null) { return NotFound(); }
            return Ok(shifts);
        }
    }
}
