using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnapecErpApi.Interfaces;
using UnapecErpData.Model;

namespace UnapecErpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPersonaController : ControllerBase
    {
        private readonly ITipoPersonaService _service;

        public TipoPersonaController(ITipoPersonaService service)
        {
            _service = service;
        }

        // GET: api/<TipoPersonaController>
        [HttpGet]
        public async Task<IEnumerable<TipoPersona>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<TipoPersonaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TipoPersonaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TipoPersonaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TipoPersonaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
