using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Services;
using PlanningsTool.Common.DTO.VerlofTypes;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerlofTypesController : ControllerBase
    {
        private readonly IVerlofTypesService _verlofTypesServices;

        public VerlofTypesController(IVerlofTypesService verlofTypesServices)
        {
            _verlofTypesServices = verlofTypesServices;
        }

        // GET api/VerlofTypes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var verlofTypes = await _verlofTypesServices.GetAll();
            if (verlofTypes == null) { return NotFound(); }
            return Ok(verlofTypes);
        }

        // GET api/VerlofTypes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var verlofType = await _verlofTypesServices.GetById(id);
            if (verlofType == null) { return NotFound(); }
            return Ok(verlofType);
        }

        // GET api/VerlofTypes/naam/{naam}
        [HttpGet("naam/{naam}")]
        public async Task<IActionResult> GetVerlofTypesByNaam(string naam)
        {
            var verlofTypes = await _verlofTypesServices.GetVerlofTypesByNaam(naam);
            if (verlofTypes == null) { return NotFound(); }
            return Ok(verlofTypes);
        }
    }
}
