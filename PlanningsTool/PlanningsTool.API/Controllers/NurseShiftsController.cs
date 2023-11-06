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

        // GET api/Zorgkundigen
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nurseShifts = await _nurseShiftsServices.GetAll();
            if (nurseShifts == null) { return NotFound(); }
            return Ok(nurseShifts);
        }

        // GET api/Zorgkundigen/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nurseShift = await _nurseShiftsServices.GetById(id);
            if (nurseShift == null) { return NotFound(); }
            return Ok(nurseShift);
        }

        // GET api/NurseShifts/date/{date}
        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetNurseShiftsByDatum(string date)
        {
            var nurseShifts = await _nurseShiftsServices.GetNurseShiftsByDate(date);
            if (nurseShifts == null) { return NotFound(); }
            return Ok(nurseShifts);
        }

        // POST api/NurseShifts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNurseShiftDTO nurseShift)
        {
            try
            {
                await _nurseShiftsServices.Add(nurseShift);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(nurseShift);
        }

        // PUT api/NurseShifts
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
