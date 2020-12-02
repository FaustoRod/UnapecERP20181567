using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnapecErpApi.Interfaces;
using UnapecErpData.Dto;
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
            try
            {
                return await _service.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }   
        }

        [HttpGet("OptionList")]
        public async Task<SelectList> GetList()
        {
            try
            {
                return new SelectList(await _service.GetAll(),"Id", "Nombre");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        // GET api/<ProvedorController>/5
        [HttpGet("{id}")]
        public async Task<Proveedor> Get(int id)
        {
            return await _service.GetSingle(id);
        }

        // GET api/<ProvedorController>/5
        [HttpPost("Search")]
        public async Task<IList<Proveedor>> GetProvedores([FromBody] ProvedorSearchDto proveedor)
        {
            return await _service.SearchProveedor(proveedor);
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
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Proveedor proveedor)
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
