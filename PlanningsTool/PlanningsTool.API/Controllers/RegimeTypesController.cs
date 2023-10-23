using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Services;
using PlanningsTool.Common.DTO.RegimeTypes;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegimeTypesController : ControllerBase
    {
        private readonly IRegimeTypesService _regimeTypesServices;

        public RegimeTypesController(IRegimeTypesService regimeTypesServices)
        {
            _regimeTypesServices = regimeTypesServices;
        }

        // GET api/RegimeTypes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regimeTypes = await _regimeTypesServices.GetAll();
            if (regimeTypes == null) { return NotFound(); }
            return Ok(regimeTypes);
        }

        // GET api/RegimeTypes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var regimeType = await _regimeTypesServices.GetById(id);
            if (regimeType == null) { return NotFound(); }
            return Ok(regimeType);
        }

        // GET api/RegimeTypes/naam/{naam}
        [HttpGet("naam/{naam}")]
        public async Task<IActionResult> GetRegimeTypesByNaam(string naam)
        {
            var regimeTypes = await _regimeTypesServices.GetRegimeTypesByNaam(naam);
            if (regimeTypes == null) { return NotFound(); }
            return Ok(regimeTypes);
        }

        // GET api/RegimeTypes/aantalUren/{aantalUrens}
        [HttpGet("aantalUren/{aantalUren}")]
        public async Task<IActionResult> GetRegimeTypesByAantalUren(string aantalUren)
        {
            var regimeTypes = await _regimeTypesServices.GetRegimeTypesByAantalUren(aantalUren);
            if (regimeTypes == null) { return NotFound(); }
            return Ok(regimeTypes);
        }
    }
}
