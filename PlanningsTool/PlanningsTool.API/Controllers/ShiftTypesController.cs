using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Services;
using PlanningsTool.Common.DTO.ShiftTypes;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftTypesController : ControllerBase
    {
        private readonly IShiftTypesService _shiftTypesServices;

        public ShiftTypesController(IShiftTypesService shiftTypesServices)
        {
            _shiftTypesServices = shiftTypesServices;
        }

        // GET api/ShiftTypes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shiftTypes = await _shiftTypesServices.GetAll();
            if (shiftTypes == null) { return NotFound(); }
            return Ok(shiftTypes);
        }

        // GET api/ShiftTypes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shiftType = await _shiftTypesServices.GetById(id);
            if (shiftType == null) { return NotFound(); }
            return Ok(shiftType);
        }

        // GET api/ShiftTypes/naam/{naam}
        [HttpGet("naam/{naam}")]
        public async Task<IActionResult> GetShiftTypesByNaam(string naam)
        {
            var shiftTypes = await _shiftTypesServices.GetShiftTypesByNaam(naam);
            if (shiftTypes == null) { return NotFound(); }
            return Ok(shiftTypes);
        }
    }
}
