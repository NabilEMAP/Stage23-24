using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamsServices.GetAll();
            if (teams == null) { return NotFound(); }
            return Ok(teams);
        }

        // GET api/Teams/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _teamsServices.GetById(id);
            if (team == null) { return NotFound(); }
            return Ok(team);
        }

        // POST api/Teams
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTeamDTO team)
        {
            await _teamsServices.Add(team);
            return Ok(team);
        }

        // PUT api/Teams
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