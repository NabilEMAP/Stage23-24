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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shifts = await _shiftsServices.GetAll();
            if (shifts == null) { return NotFound(); }
            return Ok(shifts);
        }

        // GET api/Shifts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shift = await _shiftsServices.GetById(id);
            if (shift == null) { return NotFound(); }
            return Ok(shift);
        }

        // GET api/Shifts/starttime/{starttime}
        [HttpGet("starttime/{starttime}")]
        public async Task<IActionResult> GetShiftsByStarttime(string starttime)
        {
            var shifts = await _shiftsServices.GetShiftsByStarttime(starttime);
            if (shifts == null) { return NotFound(); }
            return Ok(shifts);
        }

        // GET api/Shifts/endtime/{endtime}
        [HttpGet("endtime/{endtime}")]
        public async Task<IActionResult> GetShiftsByEndtime(string endtime)
        {
            var shifts = await _shiftsServices.GetShiftsByEndtime(endtime);
            if (shifts == null) { return NotFound(); }
            return Ok(shifts);
        }
    }
}
