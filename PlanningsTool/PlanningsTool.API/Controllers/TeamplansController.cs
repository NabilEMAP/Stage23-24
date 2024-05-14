using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Teamplans;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamplansController : Controller
    {
        private readonly ITeamplansService _teamplansServices;

        public TeamplansController(ITeamplansService teamplansServices)
        {
            _teamplansServices = teamplansServices;
        }

        // GET api/Teamplans
        /// <summary>
        /// Retrieves all team plans.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teamplans = await _teamplansServices.GetAll();
            if (teamplans == null) { return NotFound(); }
            return Ok(teamplans);
        }

        // GET api/Teamplans/{id}
        /// <summary>
        /// Retrieves a team plan by its ID.
        /// </summary>
        /// <param name="id">The ID of the team plan to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teamplan = await _teamplansServices.GetById(id);
            if (teamplan == null) { return NotFound(); }
            return Ok(teamplan);
        }

        // GET api/Teamplans/name/{name}
        /// <summary>
        /// Retrieves team plans by name.
        /// </summary>
        /// <param name="name">The name of the team plans to retrieve.</param>
        /// <returns></returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetTeamplansByName(string name)
        {
            var teamplans = await _teamplansServices.GetTeamplansByName(name);
            if (teamplans == null) { return NotFound(); }
            return Ok(teamplans);
        }

        // GET api/Teamplans/planFor/{planFor}        
        /// <summary>
        /// Retrieves team plans by planned for.
        /// </summary>
        /// <param name="planFor">The planned date of the team plans to retrieve (format: YYYY-MM).</param>
        /// <returns></returns>
        [HttpGet("planFor/{planFor}")]
        public async Task<IActionResult> GetTeamplansByPlanFor(string planFor)
        {
            var teamplans = await _teamplansServices.GetTeamplansByPlanFor(planFor);
            if (teamplans == null) { return NotFound(); }
            return Ok(teamplans);
        }

        // GET api/Teamplans/createdOn/{createdOn}
        /// <summary>
        /// Retrieves team plans by planned for.
        /// </summary>
        /// <param name="createdOn">What date the team plan is created on.(format: YYYY-MM).</param>
        /// <returns></returns>
        [HttpGet("createdOn/{createdOn}")]
        public async Task<IActionResult> GetTeamplansByCreatedOn(string createdOn)
        {
            var teamplans = await _teamplansServices.GetTeamplansByCreatedOn(createdOn);
            if (teamplans == null) { return NotFound(); }
            return Ok(teamplans);
        }

        // POST api/Teamplans
        /// <summary>
        /// Creates a new team plan.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTeamplanDTO teamplan)
        {
            await _teamplansServices.Add(teamplan);
            return Ok(teamplan);
        }

        // PUT api/Teamplans
        /// <summary>
        /// Updates an existing team plan by its ID
        /// </summary>
        /// <param name="id">The ID of the team plan to update.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTeamplanDTO teamplan)
        {
            if (teamplan == null)
            {
                return NotFound();
            }
            await _teamplansServices.Update(id, teamplan);
            return Ok(teamplan);
        }

        // DELETE api/Teamplans
        /// <summary>
        /// Deletes a team plan by its ID.
        /// </summary>
        /// <param name="id">The ID of the team plan to delete.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teamplan = await _teamplansServices.GetById(id);
            if (teamplan == null)
            {
                return NotFound();
            }
            await _teamplansServices.Delete(id);
            return NoContent();
        }
    }
}