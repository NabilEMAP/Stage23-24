using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Zorgkundigen;
using PlanningsTool.Common.DTO.ZorgkundigeShifts;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZorgkundigeShiftsController : Controller
    {
        private readonly IZorgkundigeShiftsService _zorgkundigeShiftsServices;

        public ZorgkundigeShiftsController(IZorgkundigeShiftsService zorgkundigeShiftsServices)
        {
            _zorgkundigeShiftsServices = zorgkundigeShiftsServices;
        }

        // GET api/Zorgkundigen
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var zorgkundigeShifts = await _zorgkundigeShiftsServices.GetAll();
            if (zorgkundigeShifts == null) { return NotFound(); }
            return Ok(zorgkundigeShifts);
        }

        // GET api/Zorgkundigen/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var zorgkundigeShift = await _zorgkundigeShiftsServices.GetById(id);
            if (zorgkundigeShift == null) { return NotFound(); }
            return Ok(zorgkundigeShift);
        }

        // GET api/ZorgkundigeShifts/datum/{datum}
        [HttpGet("datum/{datum}")]
        public async Task<IActionResult> GetZorgkundigeShiftsByDatum(string datum)
        {
            var zorgkundigen = await _zorgkundigeShiftsServices.GetZorgkundigeShiftsByDatum(datum);
            if (zorgkundigen == null) { return NotFound(); }
            return Ok(zorgkundigen);
        }

        // POST api/ZorgkundigeShifts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateZorgkundigeShiftDTO zorgkundigeShift)
        {
            try
            {
                await _zorgkundigeShiftsServices.Add(zorgkundigeShift);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(zorgkundigeShift);
        }

        // PUT api/ZorgkundigeShifts
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateZorgkundigeShiftDTO zorgkundigeShift)
        {
            if (zorgkundigeShift == null)
            {
                return NotFound();
            }
            await _zorgkundigeShiftsServices.Update(id, zorgkundigeShift);
            return Ok(zorgkundigeShift);
        }

        // DELETE api/ZorgkundigeShifts
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var zorgkundigeShift = await _zorgkundigeShiftsServices.GetById(id);
            if (zorgkundigeShift == null)
            {
                return NotFound();
            }
            await _zorgkundigeShiftsServices.Delete(id);
            return NoContent();
        }
    }
}
