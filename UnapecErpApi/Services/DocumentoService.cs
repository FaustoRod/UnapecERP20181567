using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnapecErpApi.Context;
using UnapecErpApi.Interfaces;
using UnapecErpData.Model;

namespace UnapecErpApi.Services
{
    public class DocumentoService:IDocumentoService
    {
        private readonly ErpDbContext _context;

        public DocumentoService(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Save(Documento entity)
        {
            if (entity == null) return false;
            entity.FechaCreacion = entity.FechaModificacion = DateTime.Now;
            _context.Documentos.Add(entity);
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

        public async Task<bool> Update(Documento entity)
        {
            if (entity == null) return false;
            var modelUpdate = await GetSingle(entity.Id);
            if (modelUpdate == null) return false;
            modelUpdate.EstadoDocumentoId = entity.EstadoDocumentoId;
            modelUpdate.Monto = entity.Monto;
            modelUpdate.Numero = entity.Numero;
            modelUpdate.NumeroFactura = entity.NumeroFactura;
            modelUpdate.ProveedorId = entity.ProveedorId;
            modelUpdate.FechaModificacion = DateTime.Now;
            _context.Documentos.Update(modelUpdate);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IList<Documento>> GetAll() => await _context.Documentos.ToListAsync();

        public async Task<Documento> GetSingle(int id) => await _context.Documentos.FindAsync(id);

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}