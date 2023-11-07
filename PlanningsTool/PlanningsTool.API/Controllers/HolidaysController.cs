using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidaysService _holidaysServices;

        public HolidaysController(IHolidaysService holidaysServices)
        {
            _holidaysServices = holidaysServices;
        }

        // GET api/Holidays
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var holidays = await _holidaysServices.GetAll();
            if (holidays == null) { return NotFound(); }
            return Ok(holidays);
        }

        // GET api/Holidays/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var holiday = await _holidaysServices.GetById(id);
            if (holiday == null) { return NotFound(); }
            return Ok(holiday);
        }

        // GET api/Holidays/date/{date}
        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetHolidaysByDate(string date)
        {
            var holidays = await _holidaysServices.GetHolidaysByDate(date);
            if (holidays == null) { return NotFound(); }
            return Ok(holidays);
        }

        // GET api/Holidays/name/{name}
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetHolidaysByName(string name)
        {
            var holidays = await _holidaysServices.GetHolidaysByName(name);
            if (holidays == null) { return NotFound(); }
            return Ok(holidays);
        }

        // POST api/Holidays
        [HttpPost]
        public async Task<IActionResult> Post(int year)
        {
            try
            {
                await _holidaysServices.Generate(year);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(year);
        }

        // DELETE api/Holidays
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var holidays = await _holidaysServices.GetAll(); ;
            if (holidays == null)
            {
                return NotFound();
            }
            await _holidaysServices.ClearAll();
            return NoContent();
        }
    }
}
