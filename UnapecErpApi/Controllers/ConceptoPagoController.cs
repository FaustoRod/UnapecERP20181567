using System.Collections.Generic;
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
        public async Task<ConceptoPago> Get(int id)
        {
            return await _service.GetSingle(id);
        }

        // POST api/<ConceptoPagoController>
        [HttpPost("Crear")]
        public async Task<IActionResult> Post([FromBody] ConceptoPago conceptoPago)
        {
            if(conceptoPago == null) return NotFound();
            var result = await _service.Save(conceptoPago);
            return result ? (IActionResult) Ok() : BadRequest();
        }

        // PUT api/<ConceptoPagoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ConceptoPago conceptoPago)
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
