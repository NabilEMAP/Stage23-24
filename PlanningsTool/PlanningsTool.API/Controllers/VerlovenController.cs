using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Services;
using PlanningsTool.Common.DTO.Verloven;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerlovenController : ControllerBase
    {
        private readonly IVerlovenService _verlovenServices;

        public VerlovenController(IVerlovenService verlovenServices)
        {
            _verlovenServices = verlovenServices;
        }

        // GET api/Verloven
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var verloven = await _verlovenServices.GetAll();
            if (verloven == null) { return NotFound(); }
            return Ok(verloven);
        }

        // GET api/Verloven/Details
        [HttpGet("details")]
        public async Task<IActionResult> GetAllDetails()
        {
            var verloven = await _verlovenServices.GetAllDetails();
            if (verloven == null) { return NotFound(); }
            return Ok(verloven);
        }

        // GET api/Verloven/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var verlof = await _verlovenServices.GetById(id);
            if (verlof == null) { return NotFound(); }
            return Ok(verlof);
        }

        // GET api/Verloven/startdatum/{startdatum}
        [HttpGet("startdatum/{startdatum}")]
        public async Task<IActionResult> GetVerlovenByStartdatum(string startdatum)
        {
            var verloven = await _verlovenServices.GetVerlovenByStartdatum(startdatum);
            if (verloven == null) { return NotFound(); }
            return Ok(verloven);
        }

        // GET api/Verloven/einddatum/{einddatum}
        [HttpGet("einddatum/{einddatum}")]
        public async Task<IActionResult> GetVerlovenByEinddatum(string einddatum)
        {
            var verloven = await _verlovenServices.GetVerlovenByEinddatum(einddatum);
            if (verloven == null) { return NotFound(); }
            return Ok(verloven);
        }

        // GET api/Verloven/reden/{reden}
        [HttpGet("reden/{reden}")]
        public async Task<IActionResult> GetVerlovenByReden(string reden)
        {
            var verloven = await _verlovenServices.GetVerlovenByReden(reden);
            if (verloven == null) { return NotFound(); }
            return Ok(verloven);
        }

        // POST api/Verloven
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVerlofDTO verlof)
        {
            try
            {
                await _verlovenServices.Add(verlof);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(verlof);
        }

        // PUT api/Verloven
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateVerlofDTO verlof)
        {
            if (verlof == null)
            {
                return NotFound();
            }
            await _verlovenServices.Update(id, verlof);
            return Ok(verlof);
        }

        // DELETE api/Verloven
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var verlof = await _verlovenServices.GetById(id);
            if (verlof == null)
            {
                return NotFound();
            }
            await _verlovenServices.Delete(id);
            return NoContent();
        }
    }
}
