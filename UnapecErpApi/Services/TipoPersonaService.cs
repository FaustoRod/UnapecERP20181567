using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnapecErpApi.Context;
using UnapecErpApi.Interfaces;
using UnapecErpData.Model;

namespace UnapecErpApi.Services
{
    public class TipoPersonaService:ITipoPersonaService
    {
        private readonly ErpDbContext _context;

        public TipoPersonaService(ErpDbContext context)
        {
            _context = context;
        }

        public Task<bool> Save(TipoPersona entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(TipoPersona entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<TipoPersona>> GetAll()
        {
            return await _context.TipoPersonas.ToListAsync();
        }

        public Task<TipoPersona> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}