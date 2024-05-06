using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Services;
using PlanningsTool.Common.DTO.Holidays;
using PlanningsTool.Common.DTO.Vacations;

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
        [HttpPost("generate")]
        public async Task<IActionResult> Post(int year)
        {
            //try
            //{
            await _holidaysServices.Generate(year);
            //}
            //catch (Exception ex)
            //{
            //    return NotFound(ex.Message);
            //}
            return Ok(year);
        }

        // POST api/Holidays
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateHolidayDTO holiday)
        {
            await _holidaysServices.Add(holiday);
            return Ok(holiday);
        }

        // PUT api/Vacations
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateHolidayDTO holiday)
        {
            if (holiday == null)
            {
                return NotFound();
            }
            await _holidaysServices.Update(id, holiday);
            return Ok(holiday);
        }

        // DELETE api/Holidays
        [HttpDelete("clear")]
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

        // DELETE api/Holidays
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var holidays = await _holidaysServices.GetById(id);
            if (holidays == null)
            {
                return NotFound();
            }
            await _holidaysServices.Delete(id);
            return NoContent();
        }
    }
}