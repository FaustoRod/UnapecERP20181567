﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnapecErpApi.Interfaces;
using UnapecErpData.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnapecErpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptoPagoController : ControllerBase
    {
        private readonly IConceptoPagoService _service;

        public ConceptoPagoController(IConceptoPagoService service)
        {
            _service = service;
        }

        // GET: api/<ConceptoPagoController>
        [HttpGet]
        public async Task<IList<ConceptoPago>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<ConceptoPagoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_service.GetSingle(id));
        }

        // POST api/<ConceptoPagoController>
        [HttpPost("Crear")]
        public async Task<IActionResult> Post([FromBody] string conceptoPago)
        {
            if(string.IsNullOrEmpty(conceptoPago)) return NotFound();
            var result = await _service.Save(new ConceptoPago{Descripcion = conceptoPago});
            return result ? (IActionResult) Ok() : BadRequest();
        }

        // PUT api/<ConceptoPagoController>/5
        [HttpPut]
        //[HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ConceptoPago conceptoPago)
        {
            if (conceptoPago == null) return BadRequest();
            var result = await _service.Update(conceptoPago);
            return result ? (IActionResult)Ok() : BadRequest();
        }

        // DELETE api/<ConceptoPagoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            return result ? (IActionResult) Ok() : NotFound();
        }
    }
}
