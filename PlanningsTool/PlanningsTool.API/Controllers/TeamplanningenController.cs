using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Teamplanningen;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamplanningenController : Controller
    {
        private readonly ITeamplanningenService _teamplanningenServices;

        public TeamplanningenController(ITeamplanningenService teamplanningenServices)
        {
            _teamplanningenServices = teamplanningenServices;
        }

        // GET api/Zorgkundigen
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teamplanningen = await _teamplanningenServices.GetAll();
            if (teamplanningen == null) { return NotFound(); }
            return Ok(teamplanningen);
        }

        // GET api/Zorgkundigen/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teamplanning = await _teamplanningenServices.GetById(id);
            if (teamplanning == null) { return NotFound(); }
            return Ok(teamplanning);
        }

        // GET api/Teamplanningen/datum/{datum}
        [HttpGet("datum/{datum}")]
        public async Task<IActionResult> GetTeamplanningenByMaand(string maand)
        {
            var zorgkundigen = await _teamplanningenServices.GetTeamplanningenByMaand(maand);
            if (zorgkundigen == null) { return NotFound(); }
            return Ok(zorgkundigen);
        }

        // POST api/Teamplanningen
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTeamplanningDTO teamplanning)
        {
            try
            {
                await _teamplanningenServices.Add(teamplanning);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(teamplanning);
        }

        // PUT api/Teamplanningen
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTeamplanningDTO teamplanning)
        {
            if (teamplanning == null)
            {
                return NotFound();
            }
            await _teamplanningenServices.Update(id, teamplanning);
            return Ok(teamplanning);
        }

        // DELETE api/Teamplanningen
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teamplanning = await _teamplanningenServices.GetById(id);
            if (teamplanning == null)
            {
                return NotFound();
            }
            await _teamplanningenServices.Delete(id);
            return NoContent();
        }
    }
}
