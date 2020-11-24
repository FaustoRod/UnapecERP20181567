using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UnapecErpApi.Interfaces;
using UnapecErpData.Dto;
using UnapecErpData.Model;
using UnapecErpData.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnapecErpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoService _service;

        public DocumentoController(IDocumentoService service)
        {
            _service = service;
        }

        // GET: api/<DocumentoController>
        [HttpGet]
        public async Task<IList<DocumentoViewModel>> Get()
        {
            return await _service.GetDocumentos();
        }

        // GET api/<DocumentoController>/5
        [HttpGet("{id}")]
        public async Task<Documento> Get(int id)
        {
            return await _service.GetSingle(id);
        }

        // POST api/<DocumentoController>
        [HttpPost("Crear")]
        public async Task<IActionResult> Post([FromBody] Documento documento)
        {
            if (documento == null) return NotFound();
            var result = await _service.Save(documento);
            return result ? (IActionResult)Ok() : BadRequest();
        }

        [HttpPost("Pagar/{id}")]
        public async Task<IActionResult> Pagar(int id)
        {
            var result = await _service.Pagar(id);
            return result ? (IActionResult)Ok() : BadRequest();
        }
        [HttpPost("Buscar")]
        public async Task<IList<Documento>> PostBuscar([FromBody] DocumentSearchDto documento)
        {
            return await _service.SearchDocumentos(documento);
        }

        // PUT api/<DocumentoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Documento documento)
        {
            if (documento == null) return BadRequest();
            var result = await _service.Update(documento);
            return result ? (IActionResult)Ok() : BadRequest();
        }

        // DELETE api/<DocumentoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            return result ? (IActionResult)Ok() : NotFound();
        }
    }
}
