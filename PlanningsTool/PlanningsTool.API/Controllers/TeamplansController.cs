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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teamplans = await _teamplansServices.GetAll();
            if (teamplans == null) { return NotFound(); }
            return Ok(teamplans);
        }

        // GET api/Teamplans/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teamplan = await _teamplansServices.GetById(id);
            if (teamplan == null) { return NotFound(); }
            return Ok(teamplan);
        }

        // GET api/Teamplans/date/{date}
        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetTeamplansByMonth(string month)
        {
            var zorgkundigen = await _teamplansServices.GetTeamplansByMonth(month);
            if (zorgkundigen == null) { return NotFound(); }
            return Ok(zorgkundigen);
        }

        // POST api/Teamplans
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTeamplanDTO teamplan)
        {
            try
            {
                await _teamplansServices.Add(teamplan);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(teamplan);
        }

        // PUT api/Teamplans
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
