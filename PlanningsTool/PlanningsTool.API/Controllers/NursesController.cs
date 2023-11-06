using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Nurses;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly INursesService _nursesServices;

        public NursesController(INursesService nursesServices)
        {
            _nursesServices = nursesServices;
        }

        // GET api/Nurses
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nurses = await _nursesServices.GetAll();
            if (nurses == null) { return NotFound(); }
            return Ok(nurses);
        }

        // GET api/Nurses/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nurse = await _nursesServices.GetById(id);
            if (nurse == null) { return NotFound(); }
            return Ok(nurse);
        }

        // GET api/Nurses/firstName/{firstName}
        [HttpGet("firstName/{firstName}")]
        public async Task<IActionResult> GetNursesByFirstName(string firstName)
        {
            var nurses = await _nursesServices.GetNursesByFirstName(firstName);
            if (nurses == null) { return NotFound(); }
            return Ok(nurses);
        }

        // GET api/Nurses/lastName/{lastName}
        [HttpGet("lastName/{lastName}")]
        public async Task<IActionResult> GetNursesByLastName(string lastName)
        {
            var nurses = await _nursesServices.GetNursesByLastName(lastName);
            if (nurses == null) { return NotFound(); }
            return Ok(nurses);
        }

        // POST api/Nurses
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNurseDTO nurse)
        {
            try
            {
                await _nursesServices.Add(nurse);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(nurse);
        }

        // PUT api/Nurses
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateNurseDTO nurse)
        {
            if (nurse == null)
            {
                return NotFound();
            }
            await _nursesServices.Update(id, nurse);
            return Ok(nurse);
        }

        // DELETE api/Nurses
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var nurse = await _nursesServices.GetById(id);
            if (nurse == null)
            {
                return NotFound();
            }
            await _nursesServices.Delete(id);
            return NoContent();
        }
    }
}
