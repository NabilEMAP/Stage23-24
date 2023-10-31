﻿using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Exceptions;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Feestdagen;

namespace PlanningsTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeestdagenController : ControllerBase
    {
        private readonly IFeestdagenService _feestdagenServices;

        public FeestdagenController(IFeestdagenService feestdagenServices)
        {
            _feestdagenServices = feestdagenServices;
        }

        // GET api/Feestdagen
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feestdagen = await _feestdagenServices.GetAll();
            if (feestdagen == null) { return NotFound(); }
            return Ok(feestdagen);
        }

        // GET api/Feestdagen/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feestdag = await _feestdagenServices.GetById(id);
            if (feestdag == null) { return NotFound(); }
            return Ok(feestdag);
        }

        // GET api/Feestdagen/datum/{datum}
        [HttpGet("datum/{datum}")]
        public async Task<IActionResult> GetFeestdagenByDatum(string datum)
        {
            var feestdagen = await _feestdagenServices.GetFeestdagenByDatum(datum);
            if (feestdagen == null) { return NotFound(); }
            return Ok(feestdagen);
        }

        // GET api/Feestdagen/naam/{naam}
        [HttpGet("naam/{naam}")]
        public async Task<IActionResult> GetFeestdagenByNaam(string naam)
        {
            var feestdagen = await _feestdagenServices.GetFeestdagenByNaam(naam);
            if (feestdagen == null) { return NotFound(); }
            return Ok(feestdagen);
        }

        // POST api/Feestdagen
        [HttpPost]
        public async Task<IActionResult> Post(int jaar)
        {
            try
            {
                await _feestdagenServices.Generate(jaar);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(jaar);
        }

        // DELETE api/Feestdagen
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var feestdagen = await _feestdagenServices.GetAll(); ;
            if (feestdagen == null)
            {
                return NotFound();
            }
            await _feestdagenServices.ClearAll();
            return NoContent();
        }
    }
}
