using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<IList<DocumentoViewModel>> PostBuscar([FromBody] DocumentSearchDto documento)
        {
            return await _service.SearchDocumentosNew(documento);
        }
        [HttpPost("BuscarAsiento")]
        public async Task<IList<DocumentoViewModel>> PostBuscarAsiento([FromBody] DocumentSearchDto documento)
        {
            return await _service.SearchDocumentosAsiento(documento);
        }
        [HttpPost("EnviarAsiento")]
        public async Task<bool> EnviarAsiento([FromBody] DocumentSearchDto documento)
        {
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://plutus.azure-api.net/api");
                var json = JsonConvert.SerializeObject(new
                {
                    descripcion =
                        $"CUENTAS POR PAGAR DESDE {documento.FechaDesde.ToString("d")} - HASTA {documento.FechaHasta.ToString("d")}",
                    idCuentaAuxiliar = 5,
                    inicioPeriodo = documento.FechaDesde.ToString("yyyy-MM-dd"),
                    finPeriodo = documento.FechaHasta.ToString("yyyy-MM-dd"),
                    asientos = new[]
                    {
                        new
                        {
                            idCuenta = 81,
                            monto = 500
                        }
                    }
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://plutus.azure-api.net/api/AccountingSeat/InsertAccountingSeats", content);
                if (result.IsSuccessStatusCode)
                {
                    var id = await result.Content.ReadAsStringAsync();
                    Debug.Print(id);
                }
                else
                {
                    Debug.Print(result.StatusCode.ToString());

                }
            }
            return true;
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
