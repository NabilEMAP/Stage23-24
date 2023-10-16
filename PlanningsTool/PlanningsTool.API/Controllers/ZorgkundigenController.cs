﻿using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Services;
using PlanningsTool.Common.DTO.Zorgkundigen;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZorgkundigenController : ControllerBase
    {
        private readonly IZorgkundigenService _zorgkundigenServices;

        public ZorgkundigenController(IZorgkundigenService zorgkundigenServices)
        {
            _zorgkundigenServices = zorgkundigenServices;
        }

        // GET api/Zorgkundigen
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var zorgkundigen = await _zorgkundigenServices.GetAll();
            if (zorgkundigen == null) { return NotFound(); }
            return Ok(zorgkundigen);
        }

        // GET api/Zorgkundigen/Details
        [HttpGet("details")]
        public async Task<IActionResult> GetAllDetails()
        {
            var zorgkundigen = await _zorgkundigenServices.GetAllDetails();
            if (zorgkundigen == null) { return NotFound(); }
            return Ok(zorgkundigen);
        }

        // GET api/Zorgkundigen/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var zorgkundige = await _zorgkundigenServices.GetById(id);
            if (zorgkundige == null) { return NotFound(); }
            return Ok(zorgkundige);
        }

        // GET api/Zorgkundigen/voornaam/{voornaam}
        [HttpGet("voornaam/{voornaam}")]
        public async Task<IActionResult> GetZorgkundigeByVoornaam(string voornaam)
        {
            var zorgkundigen = await _zorgkundigenServices.GetZorgkundigenByVoornaam(voornaam);
            if (zorgkundigen == null) { return NotFound(); }
            return Ok(zorgkundigen);
        }

        // GET api/Zorgkundigen/achternaam/{achternaam}
        [HttpGet("achternaam/{achternaam}")]
        public async Task<IActionResult> GetZorgkundigeByAchternaam(string achternaam)
        {
            var zorgkundigen = await _zorgkundigenServices.GetZorgkundigenByAchternaam(achternaam);
            if (zorgkundigen == null) { return NotFound(); }
            return Ok(zorgkundigen);
        }

        // POST api/Zorgkundigen
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateZorgkundigeDTO zorgkundige)
        {
            try
            {
                await _zorgkundigenServices.Add(zorgkundige);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(zorgkundige);
        }

        // PUT api/Zorgkundigen
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateZorgkundigeDTO zorgkundige)
        {
            if (zorgkundige == null)
            {
                return NotFound();
            }
            await _zorgkundigenServices.Update(id, zorgkundige);
            return Ok(zorgkundige);
        }

        // DELETE api/Zorgkundigen
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var zorgkundige = await _zorgkundigenServices.GetById(id);
            if (zorgkundige == null)
            {
                return NotFound();
            }
            await _zorgkundigenServices.Delete(id);
            return NoContent();
        }
    }
}