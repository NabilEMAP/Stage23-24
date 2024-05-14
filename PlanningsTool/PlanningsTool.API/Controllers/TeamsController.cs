using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Services;
using PlanningsTool.Common.DTO.Teams;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private readonly ITeamsService _teamsServices;

        public TeamsController(ITeamsService teamsServices)
        {
            _teamsServices = teamsServices;
        }

        // GET api/Teams
        /// <summary>
        /// Retrieves all teams.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamsServices.GetAll();
            if (teams == null) { return NotFound(); }
            return Ok(teams);
        }

        // GET api/Teams/teamName/{teamName}
        [HttpGet("teamName/{teamName}")]
        public async Task<IActionResult> GetTeamsByTeamName(string teamName)
        {
            var teamplans = await _teamsServices.GetTeamsByTeamName(teamName);
            if (teamplans == null) { return NotFound(); }
            return Ok(teamplans);
        }

        // GET api/Teams/{id}
        /// <summary>
        /// Retrieves a team by its ID.
        /// </summary>
        /// <param name="id">The ID of the team to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _teamsServices.GetById(id);
            if (team == null) { return NotFound(); }
            return Ok(team);
        }

        // POST api/Teams
        /// <summary>
        /// Creates a new team.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTeamDTO team)
        {
            await _teamsServices.Add(team);
            return Ok(team);
        }

        // PUT api/Teams
        /// <summary>
        /// Updates an existing team by its ID.
        /// </summary>
        /// <param name="id">The ID of the team to update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTeamDTO team)
        {
            if (team == null)
            {
                return NotFound();
            }
            await _teamsServices.Update(id, team);
            return Ok(team);
        }

        // DELETE api/Teams
        /// <summary>
        /// Deletes a team by its ID.
        /// </summary>
        /// <param name="id">The ID of the team to delete.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teamplan = await _teamsServices.GetById(id);
            if (teamplan == null)
            {
                return NotFound();
            }
            await _teamsServices.Delete(id);
            return NoContent();
        }
    }
}