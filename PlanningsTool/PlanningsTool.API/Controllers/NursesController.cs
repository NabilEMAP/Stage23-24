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
        /// <summary>
        /// Retrieves all nurses.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nurses = await _nursesServices.GetAll();
            if (nurses == null) { return NotFound(); }
            return Ok(nurses);
        }

        // GET api/Nurses/{id}
        /// <summary>
        /// Retrieves a nurse by their ID.
        /// </summary>
        /// <param name="id">The ID of the nurse to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nurse = await _nursesServices.GetById(id);
            if (nurse == null) { return NotFound(); }
            return Ok(nurse);
        }

        // GET api/Nurses/firstName/{firstName}
        /// <summary>
        /// Retrieves nurses by their first name.
        /// </summary>
        /// <param name="firstName">The first name of the nurse to search for.</param>
        /// <returns></returns>
        [HttpGet("firstName/{firstName}")]
        public async Task<IActionResult> GetNursesByFirstName(string firstName)
        {
            var nurses = await _nursesServices.GetNursesByFirstName(firstName);
            if (nurses == null) { return NotFound(); }
            return Ok(nurses);
        }

        // GET api/Nurses/lastName/{lastName}
        /// <summary>
        /// Retrieves nurses by their last name.
        /// </summary>
        /// <param name="lastName">The last name of the nurse to search for.</param>
        /// <returns></returns>
        [HttpGet("lastName/{lastName}")]
        public async Task<IActionResult> GetNursesByLastName(string lastName)
        {
            var nurses = await _nursesServices.GetNursesByLastName(lastName);
            if (nurses == null) { return NotFound(); }
            return Ok(nurses);
        }

        // POST api/Nurses
        /// <summary>
        /// Creates a new nurse.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNurseDTO nurse)
        {
            await _nursesServices.Add(nurse);
            return Ok(nurse);
        }

        // PUT api/Nurses
        /// <summary>
        /// Updates an existing nurse by their ID.
        /// </summary>
        /// <param name="id">The ID of the nurse to update.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Deletes a nurse by their ID.
        /// </summary>
        /// <param name="id">The ID of the nurse to delete.</param>
        /// <returns></returns>
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
