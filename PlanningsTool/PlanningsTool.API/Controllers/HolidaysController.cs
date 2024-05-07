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
        /// <summary>
        /// Retrieves all holidays.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var holidays = await _holidaysServices.GetAll();
            if (holidays == null) { return NotFound(); }
            return Ok(holidays);
        }

        // GET api/Holidays/{id}
        /// <summary>
        /// Retrieves a holiday by its ID.
        /// </summary>
        /// <param name="id">The ID of the holiday to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var holiday = await _holidaysServices.GetById(id);
            if (holiday == null) { return NotFound(); }
            return Ok(holiday);
        }

        // GET api/Holidays/date/{date}
        /// <summary>
        /// Retrieves holidays based on a specified date.
        /// </summary>
        /// <param name="date">The date to filter holidays.</param>
        /// <returns></returns>
        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetHolidaysByDate(string date)
        {
            var holidays = await _holidaysServices.GetHolidaysByDate(date);
            if (holidays == null) { return NotFound(); }
            return Ok(holidays);
        }

        // GET api/Holidays/name/{name}
        /// <summary>
        /// Retrieves holidays by their name.
        /// </summary>
        /// <param name="name">The name of the holiday.</param>
        /// <returns></returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetHolidaysByName(string name)
        {
            var holidays = await _holidaysServices.GetHolidaysByName(name);
            if (holidays == null) { return NotFound(); }
            return Ok(holidays);
        }

        // POST api/Holidays
        /// <summary>
        /// Generates holidays for a specified year.
        /// </summary>
        /// <param name="year">The year for which holidays are generated.</param>
        /// <returns></returns>
        [HttpPost("generate")]
        public async Task<IActionResult> Post(int year)
        {
            await _holidaysServices.Generate(year);
            return Ok(year);
        }

        // POST api/Holidays
        /// <summary>
        /// Creates a new holiday.
        /// </summary>
        /// <param name="holiday">The holiday information to be created.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateHolidayDTO holiday)
        {
            await _holidaysServices.Add(holiday);
            return Ok(holiday);
        }

        // PUT api/Vacations
        /// <summary>
        /// Updates an existing holiday.
        /// </summary>
        /// <param name="id">The ID of the holiday to update.</param>
        /// <param name="holiday">The updated holiday information.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Deletes all holidays.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Deletes a holiday by its ID.
        /// </summary>
        /// <param name="id">The ID of the holiday to delete.</param>
        /// <returns></returns>
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