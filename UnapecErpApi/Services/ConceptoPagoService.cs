using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnapecErpApi.Context;
using UnapecErpApi.Interfaces;
using UnapecErpData.Model;

namespace UnapecErpApi.Services
{
    public class ConceptoPagoService:IConceptoPagoService
    {
        private readonly ErpDbContext _context;

        public ConceptoPagoService(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Save(ConceptoPago entity)
        {
            if (entity == null) return false;
            entity.FechaCreacion = entity.FechaModificacion = DateTime.Now;
            entity.Activo = true;
            _context.ConceptoPago.Add(entity);
            try
            {
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Update(ConceptoPago entity)
        {
            if (entity == null) return false;
            var modelUpdate = await GetSingle(entity.Id);
            if (modelUpdate == null) return false;
            modelUpdate.Activo = entity.Activo;
            modelUpdate.Descripcion = entity.Descripcion;
            modelUpdate.FechaModificacion = DateTime.Now;
            _context.ConceptoPago.Update(modelUpdate);
            try
            {
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<IList<ConceptoPago>> GetAll() => await _context.ConceptoPago.Where(x =>x.Activo).ToListAsync();
        
        public async Task<ConceptoPago> GetSingle(int id) => await _context.ConceptoPago.Where(x => x.Id.Equals(id)).SingleOrDefaultAsync();

        public async Task<bool> Delete(int id)
        {
            var entity = await GetSingle(id);
            if (entity == null) return false;
            entity.Activo = false;
            return await Update(entity);
        }
    }
}