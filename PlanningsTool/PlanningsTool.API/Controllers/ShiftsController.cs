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

        // GET api/Shifts/starttijd/{starttijd}
        [HttpGet("starttijd/{starttijd}")]
        public async Task<IActionResult> GetShiftsByStarttijd(string starttijd)
        {
            var shifts = await _shiftsServices.GetShiftsByStarttijd(starttijd);
            if (shifts == null) { return NotFound(); }
            return Ok(shifts);
        }

        // GET api/Shifts/eindtijd/{eindtijd}
        [HttpGet("eindtijd/{eindtijd}")]
        public async Task<IActionResult> GetShiftsByEindtijd(string eindtijd)
        {
            var shifts = await _shiftsServices.GetShiftsByEindtijd(eindtijd);
            if (shifts == null) { return NotFound(); }
            return Ok(shifts);
        }

        // POST api/Shifts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateShiftDTO shift)
        {
            try
            {
                await _shiftsServices.Add(shift);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(shift);
        }

        // PUT api/Shifts
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateShiftDTO shift)
        {
            if (shift == null)
            {
                return NotFound();
            }
            await _shiftsServices.Update(id, shift);
            return Ok(shift);
        }

        // DELETE api/Shifts
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var shift = await _shiftsServices.GetById(id);
            if (shift == null)
            {
                return NotFound();
            }
            await _shiftsServices.Delete(id);
            return NoContent();
        }
    }
}
