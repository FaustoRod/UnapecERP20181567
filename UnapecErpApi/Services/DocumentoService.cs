using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnapecErpApi.Context;
using UnapecErpApi.Interfaces;
using UnapecErpData.Model;
using EstadoDocumento = UnapecErpData.Enums.EstadoDocumento;

namespace UnapecErpApi.Services
{
    public class DocumentoService:IDocumentoService
    {
        private readonly ErpDbContext _context;
        private readonly IProvedorService _provedorService;

        public DocumentoService(ErpDbContext context, IProvedorService provedorService)
        {
            _context = context;
            _provedorService = provedorService;
        }

        public async Task<bool> Save(Documento entity)
        {
            if (entity == null) return false;
            entity.EstadoDocumentoId = (int) EstadoDocumento.Pendiente;
            entity.FechaCreacion = entity.FechaModificacion = DateTime.Now;
            _context.Documentos.Add(entity);
            try
            {
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    var provedor = await _provedorService.GetSingle(entity.ProveedorId);
                    if (provedor != null)
                    {
                        provedor.Balance += entity.Monto;
                        return await _provedorService.Update(provedor);
                    }
                }
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
            modelUpdate.Fecha = entity.Fecha;
            modelUpdate.NumeroFactura = entity.NumeroFactura;
            //modelUpdate.ProveedorId = entity.ProveedorId;
            modelUpdate.FechaModificacion = DateTime.Now;
            _context.Documentos.Update(modelUpdate);
            //return await _context.SaveChangesAsync() > 0;
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