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
    public class ProvedorController : ControllerBase
    {
        private readonly IProvedorService _service;

        public ProvedorController(IProvedorService service)
        {
            _service = service;
        }

        // GET: api/<ProvedorController>
        [HttpGet]
        public async Task<IList<Proveedor>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<ProvedorController>/5
        [HttpGet("{id}")]
        public async Task<Proveedor> Get(int id)
        {
            return await _service.GetSingle(id);
        }

        // POST api/<ProvedorController>
        [HttpPost("Crear")]
        public async Task<IActionResult> Post([FromBody] Proveedor proveedor)
        {
            if (proveedor == null) return NotFound();
            var result = await _service.Save(proveedor);
            return result ? (IActionResult)Ok() : BadRequest();
        }

        // PUT api/<ProvedorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Proveedor proveedor)
        {
            if (proveedor == null) return BadRequest();
            var result = await _service.Update(proveedor);
            return result ? (IActionResult)Ok() : BadRequest();
        }

        // DELETE api/<ProvedorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            return result ? (IActionResult)Ok() : NotFound();
        }
    }
}
